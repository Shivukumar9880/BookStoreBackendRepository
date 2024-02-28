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
    public class AddressBusiness:IAddressBusiness
    {

        private IAddresseRepo _addressRepo;
        public AddressBusiness(IAddresseRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }
        public void AddAddress(AddressRequest address)
        {
            _addressRepo.AddAddress(address);
        }
        public IEnumerable<AddressResponse> GetAddress(long userId)
        {
            return _addressRepo.GetAddress(userId);
        }

        public void UpdateAddress(AddressUpdateRequest address)
        {
            _addressRepo.UpdateAddress(address);
        }
    }
}
