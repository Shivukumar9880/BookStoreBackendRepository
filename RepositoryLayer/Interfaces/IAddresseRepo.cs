using ModelLayer.ModelResponse;
using ModelLayer.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IAddresseRepo
    {
        public void AddAddress(AddressRequest address);
        public void UpdateAddress(AddressUpdateRequest address);
        public IEnumerable<AddressResponse> GetAddress(long userId);
    }
}
