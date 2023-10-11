namespace HospitalSystem.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;

        void save();
    }
}
