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
    public class OrderBusiness : IOrderBusiness
    {

        private readonly IOrderRepo _orderRepo;

        public OrderBusiness(IOrderRepo orderRepo)
        {
         this._orderRepo = orderRepo;
        }

        public List<BookResponse> Addorder(AddOrderRequest orders, long userId)
        {
           return _orderRepo.Addorder(orders, userId);
        }

        public List<BookResponse> GetAllOrders(long userId)
        {
            return _orderRepo.GetAllOrders(userId);
        }

        public List<BookResponse> OrderCart(List<AddOrderRequest> orders, long userId, string email)
        {
            return _orderRepo.OrderCart(orders, userId, email);
        }
    }
}
