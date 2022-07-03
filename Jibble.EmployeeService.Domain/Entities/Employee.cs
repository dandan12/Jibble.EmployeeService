namespace Jibble.EmployeeService.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int ReferenceId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; }
    }
}
