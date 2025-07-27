using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Day__4.Models
{
    public class Student
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name Is Required")]
       
        [MinLength(5, ErrorMessage = "Name Min Length Is 5")]
        [MaxLength(80, ErrorMessage = "Name Max Length Is 80")]
        [DisplayName("Student Name")] 
        [Column("EmployeeName")] 
        public string Name { get; set; }


        [Range(20, 40, ErrorMessage = "Age Must Be Between 20 and 40")]
        public int Age { get; set; }


        [Range(2000, 10000, ErrorMessage = "Salary Must Be Between 2000 and 10000")]
        public decimal Salary { get; set; }


        [StringLength(200, ErrorMessage = "Address Must Be Between 8 and 200", MinimumLength = 8)]
        public string Address { get; set; }


        [EmailAddress(ErrorMessage = "Please Enter A Valid Email")]
        [StringLength(120, ErrorMessage = "Email Must Be Between 4 and 120", MinimumLength = 4)]
        public string Email { get; set; }


        [MaxLength(40, ErrorMessage = "Password Max Length Is 40")]
        [MinLength(8, ErrorMessage = "Password Min Length Is 8")]
        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [NotMapped]
        [MaxLength(40, ErrorMessage = "Confirm Password Max Length Is 40")]
        [MinLength(8, ErrorMessage = "Confirm Password Min Length Is 8")]
        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password Not Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [ForeignKey(nameof(Department))]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
