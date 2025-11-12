using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Services;
using MISA.Fresher2025.Core.Interfaces.Repositories;

namespace MISA.Fresher2025.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerRepository customerRepository) : MISABaseController<Customer>(customerRepository)
    {
    }
}
