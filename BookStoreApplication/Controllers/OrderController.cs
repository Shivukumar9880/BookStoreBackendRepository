using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;

namespace BookStoreApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness _orderBusiness;

        public OrderController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }


        [HttpPost("AddOrder")]
        public IActionResult AddOrder([FromBody] AddOrderRequest order)
        {
            try
            {
                long userId = (long)Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                List<BookResponse> orders = _orderBusiness.Addorder(order, userId);
                return Ok(new { success = true, message = "added to orders", data = orders });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "not able to add order", data = ex.Message });
            }
        }
        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                long userId = (long)Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                List<BookResponse> orders = _orderBusiness.GetAllOrders(userId);
                return Ok(new { success = true, message = "added to orders", data = orders });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "not able to add order", data = ex.Message });
            }
        }
        
        [HttpPost("AddAll")]
        public IActionResult AddOrders([FromBody] List<AddOrderRequest> orders)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                string email = Convert.ToString(User.Claims.FirstOrDefault(x => x.Type == "Email").Value);
                List<BookResponse> bookList = _orderBusiness.OrderCart(orders, userId, email);
                return Ok(new { success = true, message = "ordered", data = bookList });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "not able to order", data = ex.Message });
            }
        }
    }
}
