using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThreeAmigos_Corp.Data;
using ThreeAmigos_Corp.Services;
using ThreeAmigos_Corp.Services.Customer;

namespace ThreeAmigos_Corp.Controllers
{
    public class CustomerController : Controller
    {
       
        private readonly ILogger _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,
                                 ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        // GET: Customer
        public async Task<IActionResult> Index([FromQuery] string subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<CustomerDto> customer = null;
            try
            {
                customer = await _customerService.GetCustomerAsync(subject);
            }
            catch
            {
                _logger.LogWarning("Error occurred using Customer service.");
                customer = Array.Empty<CustomerDto>();
            }
            return View(customer.ToList());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var customer = await _customerService.GetCustomerAsync(id.Value);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
            catch
            {
                _logger.LogWarning("Error occurred using Customer service.");
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}

