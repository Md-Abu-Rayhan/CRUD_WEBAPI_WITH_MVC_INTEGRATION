using EmployeeAPI.Data;
using EmployeeAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbHelper _dbHelper;

        public EmployeeRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        //select Op
        public List<Employee> GetEmployees(int? id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Action", "SELECT"),
                new SqlParameter("@Id", id ?? (object)DBNull.Value)
            };

            DataTable dt = _dbHelper.ExecuteStoredProcedure("SP_Employee_CRUD", parameters);
            List<Employee> employees = new();

            foreach (DataRow row in dt.Rows)
            {
                employees.Add(new Employee
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    Salary = (decimal)row["Salary"]
                });
            }

            return employees;
        }

        //Insert Op
        public void AddEmployee(Employee employee)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Action", "INSERT"),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Salary", employee.Salary)
            };

            _dbHelper.ExecuteStoredProcedure("SP_Employee_CRUD", parameters);
        }

        //Update Op
        public void UpdateEmployee(Employee employee)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Action", "UPDATE"),
                new SqlParameter("@Id", employee.Id),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Email", employee.Email),
                new SqlParameter("@Salary", employee.Salary)
            };

            _dbHelper.ExecuteStoredProcedure("SP_Employee_CRUD", parameters);
        }



        //Delete Op
        public void DeleteEmployee(int id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Action", "DELETE"),
                new SqlParameter("@Id", id)
            };

            _dbHelper.ExecuteStoredProcedure("SP_Employee_CRUD", parameters);
        }




    }
}
