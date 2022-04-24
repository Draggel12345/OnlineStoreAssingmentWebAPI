using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI_Assingment.Keys;
using StoreWebAPI_Assingment.Models.Order;
using StoreWebAPI_Assingment.Models.Product;
using StoreWebAPI_Assingment.Models.User;
using StoreWebAPI_Assingment.Services;

namespace StoreWebAPI_Assingment.Controllers
{
    [Route("api/[controller]")]
    [UseApiKey]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateOrder(Guid id, List<ProductModel> cart)
        {
            var order = await _service.CreateOrderAsync(id, cart);
            if (order != null)
            {
                return new OkObjectResult(order);
            }

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return new OkObjectResult(await _service.GetOrdersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _service.GetOrderAsync(id);
            if (order != null)
            {
                return new OkObjectResult(order);
            }

            return new NotFoundResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid userId, OrderRowUpdate orderRow)
        {
            var orderEntity = await _service.UpdateOrderAsync(userId, orderRow);
            if (orderRow != null)
            {
                return new OkObjectResult(orderRow);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            if (await _service.DeleteOrderAsync(id))
            {
                return new OkResult();
            }

            return new BadRequestResult();
        }
    }
}
