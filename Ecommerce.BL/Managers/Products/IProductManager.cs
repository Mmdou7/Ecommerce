using Ecommerce.BL.DTOs;

namespace Ecommerce.BL;

public interface IProductManager
{
    IEnumerable<ProductReadDTO> GetProducts();
    ProductReadDTO GetById(int id);
    int Add(ProductAddDTO user);
    bool Update(ProductUpdateDTO user);
    bool Delete(int id);
}
