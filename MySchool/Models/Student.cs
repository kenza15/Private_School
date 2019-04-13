using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal TuitionFees { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, First name: {FirstName}, last name is: {LastName}, date of birth is: " +
                   $"{DateOfBirth.ToShortDateString()} and tution fees is: {TuitionFees}";
        }

        
    }
}
