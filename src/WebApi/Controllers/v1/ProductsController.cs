using Application.Features.Commands;
using Application.Features.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : VersionApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Product> response = await Mediator.Send(new GetAllProductsQuery());
            if (response == null) return NotFound("Not found products");
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product response = await Mediator.Send(new GetProductByIdQuery { Id = id });
            if (response == null) return NotFound("Not found product id");
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int response = await Mediator.Send(new DeleteProductByIdCommand { Id = id });
            if (response == 0) return NotFound("Not found product id");
            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id) return BadRequest();

            Product resposne = await Mediator.Send(command);
            if (resposne == null) return NotFound("Not found product to update");

            return Ok(resposne);
        }
    }
}
