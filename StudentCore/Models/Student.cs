using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCore.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sid { get; set; }
        [Required(ErrorMessage ="Name is Require")]
        public String Sname { get; set; }
        [Required(ErrorMessage = "Address is Require")]
        public String Address { get; set; }
       
        [Required(ErrorMessage = "Email is Require")]

        public String Semail { get; set; }
        [Required(ErrorMessage = "Mobile no is Require")]
        public String Smobno { get; set; }
        
        [Required(ErrorMessage = "Gender is Require")]
        public String Gender{ get; set; }
        [Required(ErrorMessage = "Course is Require")]
        public String Course { get; set; }
    }
}
