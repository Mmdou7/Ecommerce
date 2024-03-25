using Ecommerce.BL;
using Ecommerce.BL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;  
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<List<ProductReadDTO>> GetAll()
        {
            return _productManager.GetProducts().ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductReadDTO> GetById(int id)
        {
            return _productManager.GetById(id);
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult Add(ProductAddDTO product)
        {
            var newId = _productManager.Add(product);
            return CreatedAtAction(nameof(GetById),
                new { Id = newId },
                new GeneralResponse("Added Successfully"));
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult Update(ProductUpdateDTO product)
        {
            var isFound = _productManager.Update(product);
            if (!isFound)
                NotFound();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var isFound = _productManager.Delete(id);

            if (!isFound)
                NotFound();

            return NoContent();
        }
    }
}
