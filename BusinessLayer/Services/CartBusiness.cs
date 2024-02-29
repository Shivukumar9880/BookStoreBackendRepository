using BusinessLayer.Interfaces;
using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CartBusiness:ICartBusiness
    {
        private ICartRepo _cartRepo;
        public CartBusiness(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public List<BookResponse> AddToCart(AddToCartRequest cartRequest, long userId)
        {
            return _cartRepo.AddToCart(cartRequest, userId);
        }

     

        public List<BookResponse> GetCartBooks(long userId)
        {
            return _cartRepo.GetCartBooks(userId);
        }

        public double GetPriceInCart(long userId)
        {
            return _cartRepo.GetPriceInCart(userId);
        }
        public void UpdateBookQuantity(long userId, QuantityUpdateRequest req)
        {
            _cartRepo.UpdateBookQuantity(userId, req);
        }

        public void DeleteBook(int bookId, long userId)
        {
           _cartRepo.DeleteBook(bookId, userId);
        }
    }
}
