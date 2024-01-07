namespace CarWash.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
