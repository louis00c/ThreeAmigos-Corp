using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigos_Corp.Services.Customer
{
    public class FakeCustomerService : ICustomerService
    {
         
        private readonly CustomerDto[] _customer =
        {
            new CustomerDto { Id = 1, CustomerId = 1, CustomerName = "Larry", DeliveryAddress = "Os 12", TelephoneNumber= 9000333},
            new CustomerDto { Id = 2, CustomerId = 2, CustomerName = "Joe", DeliveryAddress = "Ps 12", TelephoneNumber= 9000222},
            new CustomerDto { Id = 3, CustomerId = 3, CustomerName = "Carry", DeliveryAddress = "Lys 12", TelephoneNumber= 0772222 },
            new CustomerDto { Id = 4, CustomerId = 4, CustomerName = "Merry", DeliveryAddress = "Sas 12", TelephoneNumber= 4778992},
            new CustomerDto { Id = 5, CustomerId = 5, CustomerName = "Berry", DeliveryAddress = "Nem 12", TelephoneNumber= 22003332}

        };

        public Task<CustomerDto> GetCustomerAsync(int id)
        {
            var customer = _customer.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(customer);
        }

        public Task<IEnumerable<CustomerDto>> GetCustomerAsync(string subject)
        {
            var customer = _customer.AsEnumerable();
            if (subject != null)
            {
                customer = customer.Where(r => r.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase));
            }
            return Task.FromResult(customer);
        }
    }
}

