using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_of_SL.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage ="First name cannot be longer than 20 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$",ErrorMessage ="The First character of Firstname should be uppercase")]
        [Column("First_Name")]
        [Display(Name ="First Name")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$" , ErrorMessage = "The First character of Lastname should be uppercase")]
        [Display(Name ="Last Name")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}", ApplyFormatInEditMode =true)]
        [Display(Name ="Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return Lastname + " " + Firstname; }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
