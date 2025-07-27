using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Day__4.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("Student Name")]
        public string Name { get; set; }
         public string Address { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
