namespace Jibble.EmployeeService.Domain.Requests
{
    public class UploadEmployeeCsvRequest
    {
        public int ReferenceId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; }
    }
}
