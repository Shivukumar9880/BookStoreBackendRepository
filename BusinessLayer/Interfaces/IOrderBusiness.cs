using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOrderBusiness
    {
        public List<BookResponse> Addorder(AddOrderRequest orders, long userId);
        public List<BookResponse> GetAllOrders(long userId);
        public List<BookResponse> OrderCart(List<AddOrderRequest> orders, long userId, string email);
    }
}
