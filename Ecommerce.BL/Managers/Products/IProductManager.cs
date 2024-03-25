using Ecommerce.BL.DTOs;

namespace Ecommerce.BL;

public interface IProductManager
{
    IEnumerable<ProductReadDTO> GetProducts();
    ProductReadDTO GetById(int id);
    int Add(ProductAddDTO product);
    bool Update(ProductUpdateDTO product);
    bool Delete(int id);
}
