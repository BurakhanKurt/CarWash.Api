using CarWash.Entity.Entities;
using CarWash.Repository.Context;
using CarWash.Repository.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Repository.Repositories.Employees
{
    public class EmployeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<string> GetEmployeeRole(int userId)
        {
            return await FindByCondition(e => e.Id == userId, false).Select(e => e.Role.RoleName).FirstOrDefaultAsync();
        }
    }
}
