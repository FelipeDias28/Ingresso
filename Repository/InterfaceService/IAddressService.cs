using Ingresso.Data.DTOs;
using Ingresso.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository.InterfaceService
{
    public interface IAddressService
    {
        Task<Address> CreateAddress(CreateAddressDto model);
        Task<List<Address>> GetAddresses();
    }
}
