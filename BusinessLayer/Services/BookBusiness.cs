using BusinessLayer.Interfaces;
using ModelLayer.ModelResponse;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{

    public class BookBusiness:IBookBusiness
    {
        private IBookRepo bookRepo;
        public BookBusiness(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public BookResponse getBookById(int id)
        {
            return bookRepo.GetBookById(id);
        }
        public List<BookResponse> getAllBooks()
        {
            return bookRepo.getAllBooks();
        }

        public BookResponse getBookByName(string name)
        {
            return bookRepo.getBookByName(name);
        }

        public List<BookResponse> GetBookByAuthorName(string authorName)
        {
            return bookRepo.GetBookByAuthorName(authorName);
        }

        public List<BookResponse> GetBookByTitleAndAuthorName(string title, string authorName)
        {
            return bookRepo.GetBookByTitleAndAuthorName(title, authorName);
        }
    }
}
