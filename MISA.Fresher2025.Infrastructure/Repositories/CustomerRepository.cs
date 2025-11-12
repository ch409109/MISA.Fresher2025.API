using Microsoft.Extensions.Configuration;
using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository 
    {
        public CustomerRepository(IConfiguration config) : base(config)
        {
        }
    }
}
