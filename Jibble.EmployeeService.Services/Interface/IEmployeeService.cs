namespace Jibble.EmployeeService.Services.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> IntersectEmployeeFromSource(List<UploadEmployeeCsvRequest> requests);
    }
}
