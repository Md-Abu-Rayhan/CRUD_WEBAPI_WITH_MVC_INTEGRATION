using EmployeeMVCApp.Models;

namespace EmployeeMVCApp.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public EmployeeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }



        // Get All Employees
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>($"{_apiBaseUrl}/getall");
        }



        // Insert Employee
        public async Task<bool> InsertEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/insert", employee);
            return response.IsSuccessStatusCode;
        }

        // Update Employee
        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/update", employee);
            return response.IsSuccessStatusCode;
        }

        // Delete Employee
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/delete/{id}");
            return response.IsSuccessStatusCode;
        }






    }
}
