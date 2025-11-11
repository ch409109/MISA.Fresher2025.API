using MISA.Fresher2025.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(string customerId);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(string customerId, Customer customer);
        void DeleteCustomer(string customerId);
    }
}
