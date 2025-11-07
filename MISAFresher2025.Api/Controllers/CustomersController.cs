using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using MISA.Fresher2025.Api.Model;

namespace MISA.Fresher2025.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : MISABaseController<Customer>
    {
    }
}
