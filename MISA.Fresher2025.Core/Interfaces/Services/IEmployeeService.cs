using MISA.Fresher2025.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(string employeeId);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(string employeeId, Employee employee);
        void DeleteEmployee(string employeeId);
    }
}
