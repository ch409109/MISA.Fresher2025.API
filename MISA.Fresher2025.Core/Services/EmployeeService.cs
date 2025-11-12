using MISA.Fresher2025.Core.Entities;
using MISA.Fresher2025.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Services
{
    public class EmployeeService(IEmployeeService employeeService) : IEmployeeService
    {
        public void CreateEmployee(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.EmployeeName))
            {
                throw new Exception("Tên nhân viên không được để trống.");
            }
        }

        public void DeleteEmployee(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(string employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(string employeeId, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
