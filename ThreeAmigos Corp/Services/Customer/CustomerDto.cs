using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigos_Corp.Services.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string DeliveryAddress { get; set; }

        public int TelephoneNumber { get; set; }
        public string Subject { get;  set; }
    }
}
