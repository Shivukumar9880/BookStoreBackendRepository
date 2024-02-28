using BusinessLayer.Interfaces;
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
    public class AddressController : ControllerBase
    {
        private IAddressBusiness addressBusiness;
        public AddressController(IAddressBusiness address)
        {
            this.addressBusiness = address;
        }
        [HttpPost("addAddress")]
        public IActionResult AddAddress([FromBody] AddressRequest addAddress)
        {
            try
            {
                addAddress.userId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);//getting value in string  then convert back into integer
                addressBusiness.AddAddress(addAddress);
                return Ok(new { success = true, message = "added address" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "not able to add the address" });
            }
        }

        [HttpPut("UpdateAddress")]
        public IActionResult UpdateAddress([FromBody] AddressUpdateRequest addAddress)
        {
            try
            {
                addAddress.userId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);//getting value in string  then convert back into integer
                addressBusiness.UpdateAddress(addAddress);
                return Ok(new { success = true, message = " address updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "not able to update the address" });
            }
        }





        [HttpGet("get_address")]
        public IActionResult GetAddress()
        {
            try
            {
                long userId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                IEnumerable<AddressResponse> addresses = addressBusiness.GetAddress(userId);
                return Ok(new { success = true, message = "Address found", data = addresses });
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = "Address not found", data = e.Message });
            }
        }

    }
}
