using Jibble.EmployeeService.Domain.Entities;

namespace Jibble.EmployeeService.Services.Interface
{
    public interface IFileService
    {
        List<UploadEmployeeCsvRequest> ReadEmployeeCsv(Stream stream);
    }
}
