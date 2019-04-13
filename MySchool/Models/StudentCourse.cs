using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchool.Models
{
    public class StudentCourse
    {
        [Key]
        [Column(Order =1)]
        public int StudentId { get; set; }
        [Key]
        [Column(Order =2)]
        public int CourseId { get; set; }
        

        public Student Student { get; set; }
        public Course Course { get; set; }

        public override string ToString()
        {
            return $"Id of the Course he is enrolled is: {CourseId}";
        }

        public string displayCourses()
        {
            return $"Id of the Student is: {StudentId}";
        } 
    }
}
