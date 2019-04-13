using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    public static class TrainerManager
    {
        public static int CreateTrainer(string username, string password, string firstName, string lastName, string subject)
        {
            Trainer tr = new Trainer()
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Subject = subject
            };
            using (SchoolContext db = new SchoolContext())
            {
                db.Trainers.Add(tr);
                db.SaveChanges();
            }
            return tr.Id;
        }

        public static void CreateTrainer(int id, string subject)
        {
            Trainer tr = new Trainer()
            {
                Id=id,
                Subject = subject
            };
            using (SchoolContext db = new SchoolContext())
            {
                db.Trainers.Add(tr);
                db.SaveChanges();
            }
        }


        public static List<Trainer> GetAllTrainers()
        {
            using (SchoolContext db = new SchoolContext())
            {
                return db.Trainers.OrderBy(x => x.LastName).OrderBy(y => y.FirstName).ToList();
            }
        }

        public static void DeleteTrainer(int id)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer tr = db.Trainers.Find(id);
                if (tr == null)
                {
                    return;
                }
                db.Trainers.Remove(tr);
                db.SaveChanges();
            }
        }

        public static void UpdateTrainer(int oldId, string subject)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer= db.Trainers.Find(oldId);
                trainer.Subject = subject;
                db.SaveChanges();
            }
        }
        public static Trainer ValidateLogIn(string username, string password)
        {
            using (SchoolContext db = new SchoolContext())
            {
                var query = db.Trainers.Where(t => t.Username == username).Where(t => t.Password == password).FirstOrDefault<Trainer>();
                return query;
            }
        }

        public static Trainer FindPassword(string username)
        {
            using (SchoolContext db = new SchoolContext())
            {
                var query = db.Trainers.Where(t => t.Username == username).FirstOrDefault<Trainer>();
                return query;
            }
        }
    }
}
