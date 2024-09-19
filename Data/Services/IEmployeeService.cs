using BitsOrchestra_Test.Models;

namespace BitsOrchestra_Test.Data.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeAsync(int id);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);

    }
}
