using Esports_Org_Manager.Data;
using Esports_Org_Manager.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Esports_Org_Manager.Services
{
    public class EmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllContentCreators()
        {
            return await _context.Employees.Where(x => x.employeeTypeDiscriminator == EmployeeType.ContentCreator).ToListAsync();
        }
    }
}
