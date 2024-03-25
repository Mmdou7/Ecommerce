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
        throw new NotImplementedException();
    }
    public ProductReadDTO GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int Add(ProductAddDTO user)
    {
        throw new NotImplementedException();
    }

    public bool Update(ProductUpdateDTO user)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}
