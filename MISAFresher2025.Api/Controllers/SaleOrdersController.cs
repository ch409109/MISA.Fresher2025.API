using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repositories;
using MySqlConnector;

namespace MISA.Fresher2025.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrdersController : MISABaseController<SaleOrder>
    {
        public SaleOrdersController(IBaseRepository<SaleOrder> baseRepository) : base(baseRepository)
        {
        }
    }
}
