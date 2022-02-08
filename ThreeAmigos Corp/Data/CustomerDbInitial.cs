using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigos_Corp.Data
{
    public class CustomerDbInitial
    {
        public static async Task SeedTestData(CustomerWebAppDb context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            var customers = new List<Customer>
            {
                new Customer { Id = 1, CustomerName = "Jo" , DeliveryAddress ="KO 34" , TelephoneNumber= 99999 },
                new Customer { Id = 2, CustomerName = "Mee" , DeliveryAddress= "KO 46" , TelephoneNumber = 900033},
                new Customer { Id = 3, CustomerName = "Rex" , DeliveryAddress= "KO 56"  , TelephoneNumber = 9769202}
            };
            customers.ForEach(n => context.Customers.Add(n));
            await context.SaveChangesAsync();
        }
    }

}
