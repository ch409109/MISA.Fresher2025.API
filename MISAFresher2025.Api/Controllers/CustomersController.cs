using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Services;

namespace MISA.Fresher2025.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(CustomerService customerService)
    {
        [HttpGet]
        public List<Customer> Get()
        {
            var customers = customerService.GetCustomers();
            return customers;
        }
    }
}
