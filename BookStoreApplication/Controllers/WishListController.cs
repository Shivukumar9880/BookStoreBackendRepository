using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IwishListBusiness _iwishListBusiness;

        public WishListController(IwishListBusiness iwishListBusiness)
        {
            _iwishListBusiness = iwishListBusiness;
        }
        [HttpPost("AddToWishList")]
        public IActionResult AddToCart(int bookId)
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                List<BookResponse> WishList_item = _iwishListBusiness.AddToWishList(bookId, userId);


                return Ok(new { success = true, message = "added to WIshList", data=WishList_item });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "not able to add to wishList", data = ex.Message });
            }
        }



        [HttpGet("GetWishList")]
        public IActionResult GetCartBooks()
        {
            try
            {
                long userId = (long)(Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value));
                List<BookResponse> WishList = _iwishListBusiness.GetWishListBooks(userId);
                return Ok(new { success = true, message = "WishListItems", data = WishList });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Not able to find the cart price", data = ex.Message });
            }
        }

    }
}
