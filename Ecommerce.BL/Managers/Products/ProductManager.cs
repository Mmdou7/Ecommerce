using Ecommerce.BL.DTOs;
using Ecommerce.DAL;

namespace Ecommerce.BL;

public class ProductManager : IProductManager
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public IEnumerable<ProductReadDTO> GetProducts()
    {
        var products = _unitOfWork.ProductRepository.GetAll();
                       
        return products.Select(x => new ProductReadDTO
        {
            Id = x.Id,
            CategoryId = x.CategoryId,
            Name = x.Name,
            ProductCode = x.ProductCode,
            ImagePath = x.ImagePath,
            DiscountRate = x.DiscountRate,
            Price = x.Price,
            MinimumQuantity = x.MinimumQuantity,
        });
    }
    public ProductReadDTO GetById(int id)
    {
        var product = _unitOfWork.ProductRepository.GetById(id);
        if (product == null)
            throw new ValidationException($"Product with ID {id} not found.");

        return new ProductReadDTO
        {
            Id = id,
            CategoryId = product.CategoryId,
            Name = product.Name,
            ProductCode = product.ProductCode,
            ImagePath = product.ImagePath,
            DiscountRate = product.DiscountRate,
            Price = product.Price,
            MinimumQuantity = product.MinimumQuantity,
        };
    }

    public int Add(ProductAddDTO product)
    {
        if (_unitOfWork.ProductRepository.GetAll().Where(x => x.ProductCode == product.ProductCode).Any())
        {
            throw new ValidationException("ProductCode already exists.");
        }
        Product productEntity = new Product
        {
            CategoryId = product.CategoryId,
            Name = product.Name,
            ProductCode = product.ProductCode,
            ImagePath = product.ImagePath,
            DiscountRate = product.DiscountRate,
            Price = product.Price,
        };
        _unitOfWork.ProductRepository.Add(productEntity);
        _unitOfWork.SaveChanges();
        return productEntity.Id;
    }

    public bool Update(ProductUpdateDTO product)
    {
        Product? productEntity = _unitOfWork.ProductRepository.GetById(product.Id);

        if (productEntity == null) return false;

        productEntity.CategoryId = product.CategoryId;
        productEntity.Name = product.Name;
        productEntity.ProductCode = product.ProductCode;
        productEntity.ImagePath = product.ImagePath;
        productEntity.DiscountRate = product.DiscountRate;
        productEntity.Price = product.Price;

        _unitOfWork.ProductRepository.Update(productEntity);
        _unitOfWork.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        Product? product = _unitOfWork.ProductRepository.GetById(id);
        if (product == null) return false;

        _unitOfWork.ProductRepository.Delete(product);
        _unitOfWork.SaveChanges();

        return true;
    }
}
