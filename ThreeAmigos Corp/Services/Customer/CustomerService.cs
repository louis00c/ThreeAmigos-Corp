
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ThreeAmigos_Corp.Services.Customer;

namespace ThreeAmigos_Corp.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;

        public CustomerService(HttpClient client,IConfiguration config)
        {
            string baseUrl = config["BaseUrls:ReviewsService"];
            client.BaseAddress = new System.Uri(baseUrl);
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            var response = await _client.GetAsync("api/customer/" + id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await JsonSerializer.DeserializeAsync<CustomerDto>(await response.Content.ReadAsStreamAsync()); 
            return customer;
        }

        public Task<IEnumerable<CustomerDto>> GetCustomerAsync(string subject)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> GetReviewsAsync(string subject)
        {
            var uri = "api/reviews?category=MOV";
            if (subject != null)
            {
                uri = uri + "&subject=" + subject;
            }
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var reviews =  await JsonSerializer.DeserializeAsync<IEnumerable<CustomerDto>>(await response.Content.ReadAsStreamAsync());
            return reviews;
        }


    }
}
