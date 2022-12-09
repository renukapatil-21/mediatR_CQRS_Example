using MediatR;
using mediatRCQRS.Commands;
using mediatRCQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace mediatRCQRS.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;
        
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);    
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
            var productReturn = await _mediator.Send(new AddProductCommand(product));
            return CreatedAtRoute("GetProductById", new {id=productReturn.Id}, productReturn);
        }

        [HttpGet("{id:int}", Name ="GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);

        }
    }
}
