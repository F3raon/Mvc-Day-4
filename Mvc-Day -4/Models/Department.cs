using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Day__4.Models
{
    public class Department
    {
        [Key]
        [DisplayName("Department Id")]
        public int DeptId { get; set; }


        [DisplayName("Department Name")]
        public string DeptName { get; set; }
        
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

    }
}
