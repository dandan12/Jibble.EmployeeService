using Microsoft.EntityFrameworkCore;
namespace Jibble.EmployeeService.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task Create(T t)
        {
            _context.Add(t);
            return _context.SaveChangesAsync();
        }

        public Task Create(T[] t)
        {
            _context.AddRange(t);
            return _context.SaveChangesAsync();
        }

        public Task Upsert(T[] t)
        {
            _context.UpdateRange(t);
            return _context.SaveChangesAsync();
        }
    }
}
