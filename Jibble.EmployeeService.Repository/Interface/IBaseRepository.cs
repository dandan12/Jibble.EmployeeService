namespace Jibble.EmployeeService.Repository.Interface
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {

        Task Create(T t);
        Task Create(T[] t);
        Task Upsert(T[] t);
    }
}
