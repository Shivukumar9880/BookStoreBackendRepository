using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ModelsRequest;

namespace Book_Store_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEntityController : ControllerBase
    {
        private IUserBusiness _userBusiness;
        UserEntityController(IUserBusiness userBusiness)
        {
            this._userBusiness = userBusiness;
        }

        [HttpPost("Register")]
        public IActionResult Register(UserEntityRequestModel model)
        {
            try
            {
                var result = _userBusiness.Register(model);

                if (result != null)
                {
                    return Ok(new { sucees = true, message = "Registraion SuccessFull", data = result });
                }
                else
                {
                    return BadRequest(new { sucees = false, message = "Registraion UnSuccessFull", data = result });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
