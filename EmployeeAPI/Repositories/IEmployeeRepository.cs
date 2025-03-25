using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees(int? id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
