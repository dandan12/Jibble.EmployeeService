namespace Jibble.EmployeeService.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Employee> Contains(params int[] ids)
        {
            return _context.Employees.WhereBulkContains(ids, x => x.ReferenceId).ToList();
        }
    
    }
}