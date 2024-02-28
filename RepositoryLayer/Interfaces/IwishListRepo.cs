using ModelLayer.ModelResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IwishListRepo
    {
        public List<BookResponse> AddToWishList(int bookId, long userId);
        public List<BookResponse> GetWishListBooks(long userId);

    }
}
