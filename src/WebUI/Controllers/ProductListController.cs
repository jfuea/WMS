using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.ProductLists.Commands.CreateProductList;
using WMS.Application.ProductLists.Commands.DeleteProductList;
using WMS.Application.ProductLists.Commands.UpdateteProductList;
using WMS.Application.ProductLists.Queries.GetProducts;

namespace WMS.WebUI.Controllers
{
    [Authorize]
    public class ProductListController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<ProductsVm>> Get()
        {
            return await Mediator.Send(new GetProductQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductListCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductListCommand { Id = id });

            return NoContent();
        }
    }
}
