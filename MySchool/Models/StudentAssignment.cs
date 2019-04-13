using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchool.Models
{
    public class StudentAssignment
    {
        [Key]
        [Column(Order = 1)]
        public int StudentId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int AssignmentId { get; set; }

        public bool IsSubmitted { get; set; }
        

        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
    }
}
