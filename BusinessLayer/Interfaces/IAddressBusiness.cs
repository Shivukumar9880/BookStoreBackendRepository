using ModelLayer.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IAddressBusiness
    {
        public void AddAddress(AddressRequest address);
        public void UpdateAddress(AddressUpdateRequest address);
        public IEnumerable<ModelLayer.ModelResponse.AddressResponse> GetAddress(long userId);
    }
}
