using CarWash.Repository.Repositories.BaseRepository;
using CarWash.Entity.Entities;

namespace CarWash.Repository.Repositories.Employees
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<string> GetEmployeeRole(int userId);
    }
}
