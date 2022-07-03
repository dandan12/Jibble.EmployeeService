namespace Jibble.EmployeeService.Repository.Interface
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        List<Employee> Contains(params int[] ids);
    }
}
