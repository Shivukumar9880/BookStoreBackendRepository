using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ModelResponse;

namespace BookStoreApplication.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookBusiness bookBusiness;
        public BookController(IBookBusiness _bookBusiness)
        {
            this.bookBusiness = _bookBusiness;
        }


        [HttpGet("BookById")]
        public IActionResult getBookById(int id)
        {
            try
            {
                BookResponse book = bookBusiness.getBookById(id);
                return Ok(new { success = true, message = "book.title", data = book });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "book not found", data = ex.Message });
            }
        }
        [HttpGet("GetAll")]
        public IActionResult getAllBooks()
        {
            try
            {
                List<BookResponse> books = new List<BookResponse>();
                books = bookBusiness.getAllBooks();
                return Ok(new { success = true, message = "book", data = books });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = "not able to extract details", data = ex.Message });
            }
        }

        [HttpGet("bookByName")]
        public IActionResult GetBookByName(string name)
        {
            try
            {
                BookResponse book = bookBusiness.getBookByName(name);
                return Ok(new { sucess = true, message = "book Found", data = book });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bookByAuthorName")]
        public IActionResult GetBookByAuthorName(string name)
        {
            try
            {
                List<BookResponse> book = bookBusiness.GetBookByAuthorName(name);
                return Ok(new { sucess = true, message = "book Found", data = book });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpGet("bookByTitleAndAuthorName")]
        public IActionResult bookByTitleAndAuthorName(string title,string authro)
        {
            try
            {
                List<BookResponse> book = bookBusiness.GetBookByTitleAndAuthorName(title, authro);
                return Ok(new { sucess = true, message = "book Found", data = book });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }






    }
}
