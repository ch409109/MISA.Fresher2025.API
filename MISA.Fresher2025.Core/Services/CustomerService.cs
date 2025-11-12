using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Repositories;
using MISA.Fresher2025.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {

        public void CreateCustomer(Customer customer)
        {
            // Validate data
            if (string.IsNullOrEmpty(customer.CustomerName))
            {
                throw new Exception("Tên khách hàng không được để trống.");
            }

            customerRepository.Create(customer);
        }

        public void DeleteCustomer(string customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(string customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            return customerRepository.GetAll();
        }

        public void UpdateCustomer(string customerId, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
