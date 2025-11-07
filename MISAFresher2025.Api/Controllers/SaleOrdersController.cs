using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher2025.Api.Model;
using MySqlConnector;

namespace MISA.Fresher2025.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrdersController : MISABaseController<SaleOrder>
    {
    }
}
