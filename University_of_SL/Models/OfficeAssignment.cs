using System.ComponentModel.DataAnnotations;

namespace University_of_SL.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        [StringLength(50)]
        [Display(Name ="Location of Office")]
        public string Location { get; set; }

        public Instructor instructor { get; set; }

    }
}