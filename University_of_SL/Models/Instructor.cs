using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace University_of_SL.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(25)]
        [Display(Name ="First Name")]
        [Column("First Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}", ApplyFormatInEditMode =true)]
        [Display(Name ="Hired Date")]
        public DateTime HireDate { get; set; }

        [Display(Name ="Full Name")]
        public string FullName
        {
            get { return LastName + " " + FirstMidName; }
        }

        public ICollection<CourseAssignment> courseAssignments { get; set; }
        public OfficeAssignment officeAssignment { get; set; }
    }
}
