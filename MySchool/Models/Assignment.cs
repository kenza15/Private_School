using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Submission { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }
        


        public virtual ICollection<Student> Students { get; set; }
        public virtual Course Course { get; set; }
        public virtual Trainer Trainer { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Description is: {Description} and submission date is: {Submission.ToShortDateString()}";
        }

    }
}