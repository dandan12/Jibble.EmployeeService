using System.ComponentModel.DataAnnotations.Schema;

namespace Jibble.EmployeeService.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
