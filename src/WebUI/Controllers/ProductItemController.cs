using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.ProductItems.Commands.CreateProductItem;
using WMS.Application.ProductItems.Commands.DeleteProductItem;
using WMS.Application.ProductItems.Commands.UpdateProductItem;
using WMS.Application.ProductItems.Commands.UpdateProductItemDetail;

namespace WMS.WebUI.Controllers
{
    public class ProductItemController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, UpdateProductItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<int>> UpdateProductDetail(int id, UpdateProductItemDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            await Mediator.Send(new DeleteProductItemCommand { Id = id });

            return NoContent();
        }
    }
}
