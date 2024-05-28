using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(string id)
        {
            return Content("11");
        }
        [HttpGet("{id}/Related")]
        public IActionResult AddRelatedProduct(string id, string pathToRelatedProduct, [FromServices] LinkParser linkParser)
        {
            var routeValues = linkParser.ParsePathByEndpointName(
                nameof(GetProduct), pathToRelatedProduct);
            var relatedProductId = routeValues?["id"];

            return Content("22");
        }
    }
}
