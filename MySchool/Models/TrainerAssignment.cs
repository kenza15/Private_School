using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchool.Models
{
    public class TrainerAssignment
    {
        [Key]
        [Column(Order = 1)]
        public int TrainerID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int AssignmentId { get; set; }

        public Trainer Trainer { get; set; }
        public Assignment Assignment { get; set; }
    }
}
