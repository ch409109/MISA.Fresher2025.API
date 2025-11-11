using MISA.Fresher2025.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> Get();
        Customer GetById(string customerId);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
