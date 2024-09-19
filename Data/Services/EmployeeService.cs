using BitsOrchestra_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace BitsOrchestra_Test.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            var existedEmployee = await GetEmployeeAsync(employee.ID);
            if (existedEmployee is not null)
                throw new Exception("Unable to add item. Employee already exist.");

            await _appDbContext.Employee.AddAsync(employee);
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await GetEmployeeAsync(id);
            if (employee is null)
                throw new Exception("Unable to delete item. Employee not found");

            _appDbContext.Employee.Remove(employee);

            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _appDbContext.Employee.ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return (await _appDbContext.Employee.FirstOrDefaultAsync(e => e.ID == id))!;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            var existedEmployee = await GetEmployeeAsync(employee.ID);
            if (existedEmployee is null)
                throw new Exception("Unable to update item. Employee not found");

            _appDbContext.Employee.Update(employee);
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }
    }
}
