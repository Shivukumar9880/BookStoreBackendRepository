using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICartBusiness
    {
        public List<BookResponse> AddToCart(AddToCartRequest cartRequest, long userId);
        public List<BookResponse> GetCartBooks(long userId);
        public double GetPriceInCart(long userId);
        public void UpdateBookQuantity(long userId, QuantityUpdateRequest req);
    }


}
