using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    public static class TrainerCourseManager
    {
        static public void CreateTrainerCourse(int trainerID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                Course course = db.Courses.Find(courseID);
                TrainerCourse trainerCourse = new TrainerCourse()
                {
                    Trainer = trainer,
                    Course = course
                    
                };
                db.TrainerCourses.Add(trainerCourse);
                db.SaveChanges();
            }
        }

        static public void GetTrainerPerCourse(int courseID)
        {
            using(SchoolContext db = new SchoolContext())
            {
                var trainers = db.TrainerCourses.Where(x => x.CourseId == courseID).ToList();
                foreach(var tr in trainers)
                {
                    Console.WriteLine($"Trainer who is over the Course with id: {courseID} is the one with id: {tr.TrainerId}");
                }
                foreach (var course in CourseManager.GetAllCourses())
                {
                    Console.WriteLine(course);
                }
                foreach (var trainer in TrainerManager.GetAllTrainers())
                {
                    Console.WriteLine(trainer);
                }
            }
        }

        static public void GetCoursesPerTrainer(int trainerId)
        {
            using (SchoolContext db = new SchoolContext())
            {


                var courses = db.TrainerCourses.Where(x => x.TrainerId == trainerId).ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine($"You are over the Course with id: {course.CourseId} ");
                }
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Courses");
                foreach (var course in CourseManager.GetAllCourses())
                {
                    Console.WriteLine(course);
                }
            }
        }

        public static void UpdateTrainerPerCourse(int trainerID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                TrainerCourse trainerCourse = db.TrainerCourses.Find(trainerID, courseID);
                trainerCourse.CourseId = courseID;
                db.SaveChanges();
            }
        }

        static public void DeleteTrainerPerCourse(int trainerID, int courseID)
        {
            using (SchoolContext db = new SchoolContext())
            {
                TrainerCourse trainer = db.TrainerCourses.Find(trainerID, courseID);

                db.TrainerCourses.Remove(trainer);
                db.SaveChanges();
            }
        }

        static public List<Student> GetAllStudentsPerCourse(int trainerId)
        {
            using (SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerId);
                var query = from te in db.TrainerCourses
                            where te.TrainerId == trainer.Id
                            join c in db.Courses on te.CourseId equals c.Id
                            join se in db.StudentCourses on c.Id equals se.CourseId
                            join s in db.Students on se.StudentId equals s.Id
                            where te.CourseId == se.CourseId
                            orderby te.CourseId
                            select s;
                return query.ToList();
            }
        }

        static public List<Assignment> GetAssignmentsPerStudentPerCourse(int trainerId)
        {
            using(SchoolContext db = new SchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerId);
                var query = from te in db.TrainerCourses
                            where te.TrainerId == trainer.Id
                            join c in db.Courses on te.CourseId equals c.Id
                            join se in db.StudentCourses on c.Id equals se.CourseId
                            join s in db.Students on se.StudentId equals s.Id
                            join ass in db.Assignments on s.Id equals ass.Id
                            where ass.Id == s.Id 
                            orderby c.Id
                            select ass;

                return query.ToList();
            }
        }
    }
}
