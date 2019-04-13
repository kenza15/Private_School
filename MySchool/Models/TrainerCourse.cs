using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchool.Models
{
    public class TrainerCourse
    {
        [Key]
        [Column(Order = 1)]
        public int TrainerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CourseId { get; set; }
        
        public Trainer Trainer { get; set; }
        public Course Course { get; set; }
    }
}
