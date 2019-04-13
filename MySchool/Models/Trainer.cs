using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

        public override string ToString()
        {
            return $"Trainer with Id: {Id}, first name: {FirstName}, last name: {LastName} and his subject: {Subject}";
        }
    }
}
