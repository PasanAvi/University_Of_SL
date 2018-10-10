using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University_of_SL.Models
{
    public class EnrollementDates
    {
       [DataType(DataType.Date)]
        public DateTime? EnrollementDate { get; set; }
         public int Studentcount { get; set; }
    }
}
