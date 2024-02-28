using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ModelsRequest;
using System;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEntityController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserEntityController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost("User_Registration")]
        public IActionResult Register(UserEntityRequestModel model)
        {
            try
            {
                var result = _userBusiness.Register(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Registration Successful", data = result });
                }
                return BadRequest(new { success = false, message = "Registration Unsuccessful" });
            }
            catch (Exception ex)
            {
              

                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "An error occurred while processing the request." });
            }
        }

        [HttpPost("login")]
        public IActionResult UserLogin(UserLoginRequest loginModel)
        {
            try
            {
                var result = _userBusiness.UserLogin(loginModel);

                if (result!=null)
                {
                   return Ok(new {sucess=true,message= result[0], data = result[1] });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login Failure", data = result });
                }
            }
            catch (Exception ex)
            {

                return BadRequest("An Error Occured While Processing the Request");
            }
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {

            try
            {
                var result = _userBusiness.ForgotPassword(email);

                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Authentication Code Sended To User", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Email Is Not Found", data = result });
                }
            }
            catch (Exception ex)
            {

                return BadRequest("An Error Occured While Processing the Request");
            }
        }

        [Authorize]
        [HttpPatch("ResetPassword")]
        public IActionResult ResetPassword(string password)
        {
            try
            {
                string email = User.Claims.FirstOrDefault(x => x.Type == "Email").Value;
                if (email == null)
                {
                    return BadRequest(new { success = false, message = "Email claim not found" });
                }

                var result = _userBusiness?.ResetPassword(email, password);

                if (result != null)
                {
                    return Ok(new { success = true, message = "Password Updated Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unable To Change Password" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
