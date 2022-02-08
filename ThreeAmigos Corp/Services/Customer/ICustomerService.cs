using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeAmigos_Corp.Services.Customer;

namespace ThreeAmigos_Corp.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomerAsync(string subject);

        Task<CustomerDto> GetCustomerAsync(int id);
    }
}
