using System.Diagnostics.CodeAnalysis;

namespace Jibble.EmployeeService.Domain.Utils
{
    public class EmployeeEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            return x.ReferenceId == y.ReferenceId;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.ReferenceId.GetHashCode();
        }
    }
}
