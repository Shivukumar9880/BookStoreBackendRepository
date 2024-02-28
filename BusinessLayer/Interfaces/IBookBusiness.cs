using ModelLayer.ModelResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBookBusiness
    {
        List<BookResponse> getAllBooks();
        public BookResponse getBookById(int id);
      
        public BookResponse getBookByName(string name);

        List<BookResponse> GetBookByAuthorName(string authorName);

        List<BookResponse> GetBookByTitleAndAuthorName(string title,string authorName);
    }
}
