using CarWash.Entity.Entities;
using CarWash.Repository.Context;
using CarWash.Repository.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Repository.Repositories.AppointmentRepo
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Appointment>> GetAppointmentByCustIdAsync(int custId)
        {
            var list = await FindByCondition(a=> a.CustomerId == custId,true)
                .Include(a=> a.Vehicle)
                .ThenInclude(a=> a.Brand)
                .Include(a=> a.WashPackage)
                .Include(a=> a.WashProcess)
                .ThenInclude(a=> a.ServiceReview).ToListAsync();

            return list;
        }
    }
}
