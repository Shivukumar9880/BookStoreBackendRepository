using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IwishListBusiness
    {
        public List<BookResponse> AddToWishList(int bookId, long userId);
        public List<BookResponse> GetWishListBooks(long userId);
    }
}
