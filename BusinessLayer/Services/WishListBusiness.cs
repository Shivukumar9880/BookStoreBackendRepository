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
    public class WishListBusiness : IwishListBusiness
    {
        private readonly IwishListRepo _wishListRepo;

        public WishListBusiness(IwishListRepo wishListRepo)
        {
            _wishListRepo = wishListRepo;
        }

        public List<BookResponse> AddToWishList(int bookId, long userId)
        {
           return _wishListRepo.AddToWishList(bookId, userId);

        }

        public List<BookResponse> GetWishListBooks(long userId)
        {
            return _wishListRepo.GetWishListBooks(userId);
        }
    }
}
