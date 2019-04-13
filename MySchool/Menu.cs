using MySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    public static class Menu
    {
        public static void MainMenuHeadMaster()
        {
            User user = new User();
            bool login = false;
            while (true)
            {

                while (login == false)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    user = UserManager.FindPassword(username);
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    if (user == null)
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                    else if (SecurePasswordHasher.Verify(password, user.Password) == true)
                    {
                        Console.WriteLine("Successfull login\n");
                        login = true;
                    }
                    else
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                }



                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Add a Student");
                    Console.WriteLine("2. See all Students");
                    Console.WriteLine("3. Update Student");
                    Console.WriteLine("4. Delete Student");
                    Console.WriteLine("5. Create a Course");
                    Console.WriteLine("6. See all Courses");
                    Console.WriteLine("7. Update a Course");
                    Console.WriteLine("8. Delete a Course");
                    Console.WriteLine("9. Create an Assignment");
                    Console.WriteLine("10. See all Assignments");
                    Console.WriteLine("11. Update an Assignment");
                    Console.WriteLine("12. Delete an Assignment");
                    Console.WriteLine("13. Create a Trainer");
                    Console.WriteLine("14. See all Trainers");
                    Console.WriteLine("15. Update a Trainer");
                    Console.WriteLine("16. Delete a Trainer");
                    Console.WriteLine("17. Add a student in a Course");
                    Console.WriteLine("18. See all Students per Course or Courses per Student");
                    Console.WriteLine("19. Update a Student in a Course");
                    Console.WriteLine("20. Delete a Student from a Course");
                    Console.WriteLine("21. Add a Trainer in a Course");
                    Console.WriteLine("22. See all Trainers per Course");
                    Console.WriteLine("23. Update a Trainer per Course");
                    Console.WriteLine("24. Delete a Trainer per Course");
                    Console.WriteLine("25. Add an Assignment for a Course");
                    Console.WriteLine("26. See all Assignments per Course");
                    Console.WriteLine("27. Update an Assignment per Course");
                    Console.WriteLine("28. Delete an Assignment for a Course");
                    Console.WriteLine("29. Create a Schedule per Course");
                    Console.WriteLine("30. See a Schedule per Course");
                    Console.WriteLine("30. Update a Schedule per Course");
                    Console.WriteLine("31. Delete a Schedule from a Course");
                    Console.WriteLine("0. Exit");

                    string choise = Console.ReadLine();
                    switch (choise)
                    {
                        case "1":
                            {
                                Console.Clear();
                                Console.Write("Insert Student's Username: ");
                                string username = Console.ReadLine();
                                Console.Write("Password: ");
                                string password = Console.ReadLine();
                                string hashedPass = SecurePasswordHasher.Hash(password);
                                Console.Write("First name: ");
                                string firstName = Console.ReadLine();
                                Console.Write("Last name: ");
                                string lastName = Console.ReadLine();
                                Console.Write("Date of birth: ");
                                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine()).Date;
                                Console.Write("Tuition Fees: ");
                                decimal tuitionFees = Convert.ToDecimal(Console.ReadLine());
                                StudentManager.CreateStudent(username, hashedPass, firstName, lastName, dateOfBirth, tuitionFees);
                                Console.Clear();
                                break;
                            }
                        case "2":
                            {
                                Console.Clear();
                                foreach (var student in StudentManager.GetAllStudents())
                                {
                                    Console.WriteLine(student);
                                }
                                Console.ReadLine();

                                break;
                            }
                        case "3":
                            {
                                Console.Clear();
                                foreach (var student in StudentManager.GetAllStudents())
                                {
                                    Console.WriteLine(student);
                                }
                                Console.Write("Choose a Student to update(id): ");
                                int oldStudentID = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Insert the new first name: ");
                                string firstName = Console.ReadLine();
                                Console.Write("Insert the new last name: ");
                                string lastName = Console.ReadLine();
                                Console.Write("insert the date of birth: ");
                                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine()).Date;
                                Console.Write("Insert the new tuition fees: ");
                                decimal tuitionFees = Convert.ToDecimal(Console.ReadLine());
                                StudentManager.UpdateStudent(oldStudentID, firstName, lastName, dateOfBirth, tuitionFees);
                                break;
                            }
                        case "4":
                            {
                                Console.Clear();
                                foreach (var student in StudentManager.GetAllStudents())
                                {
                                    Console.WriteLine(student);
                                }
                                Console.Write("Give Student id to delete: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                StudentManager.DeleteStudent(id);

                                break;
                            }
                        case "5":
                            {
                                Console.Clear();
                                Console.Write("Course title: ");
                                string title = Console.ReadLine();
                                Console.Write("Course's stream(Java/C#)");
                                string stream = Console.ReadLine();
                                Console.Write("Courses's type(Full/Part)");
                                string type = Console.ReadLine();
                                Console.Write("Start Date: ");
                                DateTime startDate = Convert.ToDateTime(Console.ReadLine()).Date;
                                Console.Write("End Date: ");
                                DateTime endDate = Convert.ToDateTime(Console.ReadLine()).Date;
                                CourseManager.CreateCourse(title, stream, type, startDate, endDate);
                                Console.Clear();
                                break;
                            }
                        case "6":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.ReadLine();
                                break;
                            }
                        case "7":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Insert id of course to change: ");
                                int oldId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Insert new title");
                                string title = Console.ReadLine();
                                Console.Write("change the stream: ");
                                string stream = Console.ReadLine();
                                Console.Write("Choose the new type: ");
                                string type = Console.ReadLine();
                                Console.Write("Set new Start date: ");
                                DateTime startDate = Convert.ToDateTime(Console.ReadLine()).Date;
                                Console.Write("Set new end date: ");
                                DateTime endDate = Convert.ToDateTime(Console.ReadLine()).Date;
                                CourseManager.UpdateCourse(oldId, title, stream, type, startDate, endDate);
                                break;
                            }
                        case "8":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Give Course id to delete: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                CourseManager.DeleteCourse(id);
                                break;
                            }
                        case "9":
                            {
                                Console.Clear();
                                Console.Write("Title: ");
                                string title = Console.ReadLine();
                                Console.Write("Description: ");
                                string description = Console.ReadLine();
                                Console.Write("Submission date: ");
                                DateTime submission = Convert.ToDateTime(Console.ReadLine()).Date;
                                AssignmentManager.CreateAssignment(title, description, submission);
                                Console.Clear();
                                break;
                            }
                        case "10":
                            {
                                Console.Clear();
                                foreach (var assignment in AssignmentManager.GetAllAssignments())
                                {
                                    Console.WriteLine(assignment);
                                }
                                Console.ReadLine();
                                break;
                            }
                        case "11":
                            {
                                Console.Clear();
                                foreach (var assignment in AssignmentManager.GetAllAssignments())
                                {
                                    Console.WriteLine(assignment);
                                }
                                Console.Write("Choose assignment to update(id): ");
                                int oldId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Type new title: ");
                                string title = Console.ReadLine();
                                Console.Write("Type new description: ");
                                string description = Console.ReadLine();
                                Console.Write("insert new submission date: ");
                                DateTime submission = Convert.ToDateTime(Console.ReadLine()).Date;
                                AssignmentManager.UpdateAssignment(oldId, title, description, submission);
                                break;
                            }
                        case "12":
                            {
                                Console.Clear();
                                foreach (var assignment in AssignmentManager.GetAllAssignments())
                                {
                                    Console.WriteLine(assignment);
                                }
                                Console.Write("Give assignment id to delete: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                AssignmentManager.DeleteAssignment(id);
                                break;
                            }
                        case "13":
                            {
                                Console.Write("Insert Trainer's Username: ");
                                string username = Console.ReadLine();
                                Console.Write("Password: ");
                                string password = Console.ReadLine();
                                string hashedPass = SecurePasswordHasher.Hash(password);
                                Console.Clear();
                                Console.Write("First name: ");
                                string firstName = Console.ReadLine();
                                Console.Write("Last name: ");
                                string lastName = Console.ReadLine();
                                Console.Write("Subject: ");
                                string subject = Console.ReadLine();
                                TrainerManager.CreateTrainer(username, hashedPass, firstName, lastName, subject);
                                Console.Clear();
                                break;
                            }
                        case "14":
                            {
                                Console.Clear();
                                foreach (var trainer in TrainerManager.GetAllTrainers())
                                {
                                    Console.WriteLine(trainer);
                                }
                                Console.ReadLine();
                                break;
                            }
                        case "15":
                            {
                                Console.Clear();
                                foreach (var trainer in TrainerManager.GetAllTrainers())
                                {
                                    Console.WriteLine(trainer);
                                }
                                Console.Write("Choose trainer to update");
                                int oldId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Type his new subject");
                                string subject = Console.ReadLine();
                                TrainerManager.UpdateTrainer(oldId, subject);
                                Console.ReadLine();
                                break;
                            }
                        case "16":
                            {
                                Console.Clear();
                                foreach (var trainer in TrainerManager.GetAllTrainers())
                                {
                                    Console.WriteLine(trainer);
                                }
                                Console.Write("Give Trainer id to delete: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                TrainerManager.DeleteTrainer(id);
                                break;
                            }
                        case "17":
                            {
                                Console.Clear();
                                foreach (var student in StudentManager.GetAllStudents())
                                {
                                    Console.WriteLine(student);
                                }
                                Console.Write("Select the id of the Student: ");
                                int studentID = Convert.ToInt32(Console.ReadLine());
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Select the id of the Course: ");
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                StudentCourseManager.CreateStudentCourse(studentID, courseID);
                                break;
                            }
                        case "18":
                            {
                                Console.Write("You want to see the Courses of one student(1), or the Students in a Course(2)?: ");
                                string ch = Console.ReadLine();
                                if (ch == "1")
                                {
                                    Console.Clear();
                                    foreach (var student in StudentManager.GetAllStudents())
                                    {
                                        Console.WriteLine(student);
                                    }
                                    Console.Write("Give the id of the student: ");
                                    int studentID = Convert.ToInt32(Console.ReadLine());
                                    StudentCourseManager.GetCoursesPerStudent(studentID);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.Clear();
                                    foreach (var course in CourseManager.GetAllCourses())
                                    {
                                        Console.WriteLine(course);
                                    }
                                    Console.Write("Give the id of the course: ");
                                    int courseID = Convert.ToInt32(Console.ReadLine());
                                    StudentCourseManager.GetStudentsPerCourse(courseID);
                                    Console.ReadLine();
                                }
                                break;
                            }
                        case "19":
                            {
                                Console.Clear();
                                foreach (var student in StudentManager.GetAllStudents())
                                {
                                    Console.WriteLine(student);
                                }
                                Console.Write("Choose a student(id): ");
                                int studentId = Convert.ToInt32(Console.ReadLine());
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Choose the new id of the course: ");
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                StudentCourseManager.UpdateStudentCourse(studentId, courseID);
                                break;
                            }
                        case "20":
                            {
                                Console.Clear();
                                Console.Write("which student(id) you want to delete from a course?: ");

                                int studentID = Convert.ToInt32(Console.ReadLine());
                                Console.Write("And from which course(id)?: ");
                                StudentCourseManager.GetCoursesPerStudent(studentID);
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                StudentCourseManager.DeleteStudentPerCourse(studentID, courseID);
                                break;
                            }
                        case "21":
                            {
                                foreach (var trainer in TrainerManager.GetAllTrainers())
                                {
                                    Console.WriteLine(trainer);
                                }
                                Console.Write("Choose a trainer: ");
                                int trainerId = Convert.ToInt32(Console.ReadLine());
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("choose a course to see the trainers: ");
                                int courseId = Convert.ToInt32(Console.ReadLine());
                                TrainerCourseManager.CreateTrainerCourse(trainerId, courseId);
                                break;
                            }
                        case "22":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("select the course to view trainers: ");
                                int courseId = Convert.ToInt32(Console.ReadLine());
                                TrainerCourseManager.GetTrainerPerCourse(courseId);
                                break;
                            }
                        case "23":
                            {
                                Console.Clear();
                                foreach (var trainer in TrainerManager.GetAllTrainers())
                                {
                                    Console.WriteLine(trainer);
                                }
                                Console.Write("select a trainer id to update his course: ");
                                int trainerID = Convert.ToInt32(Console.ReadLine());
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Select the new course(id): ");
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                TrainerCourseManager.UpdateTrainerPerCourse(trainerID, courseID);
                                break;
                            }
                        case "24":
                            {
                                Console.Clear();
                                foreach (var trainer in TrainerManager.GetAllTrainers())
                                {
                                    Console.WriteLine(trainer);
                                }
                                Console.Write("select a trainer id to delete from a course: ");
                                int trainerID = Convert.ToInt32(Console.ReadLine());
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Select the course(id): ");
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                TrainerCourseManager.DeleteTrainerPerCourse(trainerID, courseID);
                                break;
                            }
                        case "25":
                            {
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Choose a course(id): ");
                                int courseId = Convert.ToInt32(Console.ReadLine());
                                foreach (var assignment in AssignmentManager.GetAllAssignments())
                                {
                                    Console.WriteLine(assignment);
                                }
                                Console.Write("choose an assignment to add to courses: ");
                                int assignmentId = Convert.ToInt32(Console.ReadLine());
                                CourseAssignmentManager.CreateCourseAssignment(courseId, assignmentId);
                                break;
                            }
                        case "26":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("select the course to view assignments: ");
                                int courseId = Convert.ToInt32(Console.ReadLine());
                                CourseAssignmentManager.GetAssignmentsPerCourse(courseId);
                                break;
                            }
                        case "27":
                            {
                                Console.Clear();
                                foreach (var assignment in AssignmentManager.GetAllAssignments())
                                {
                                    Console.WriteLine(assignment);
                                }
                                Console.Write("select an assignment id to update his course: ");
                                int assignmentID = Convert.ToInt32(Console.ReadLine());
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Select the new course(id): ");
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                CourseAssignmentManager.UpdateAssignmentCourse(assignmentID, courseID);
                                break;
                            }
                        case "28":
                            {
                                Console.Clear();
                                foreach (var assignment in AssignmentManager.GetAllAssignments())
                                {
                                    Console.WriteLine(assignment);
                                }
                                Console.Write("select an assignment id to delete from a course: ");
                                int assignmentID = Convert.ToInt32(Console.ReadLine());
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Select the course(id): ");
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                TrainerCourseManager.DeleteTrainerPerCourse(assignmentID, courseID);
                                break;
                            }
                        case "29":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course.Id + "--" + course.Title);
                                }
                                Console.Write("Choose the Course to make the schedule(id): ");
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                Console.Write("When will start?: ");
                                DateTime startDate = Convert.ToDateTime(Console.ReadLine()).Date;
                                Console.Write("When will end?: ");
                                DateTime endDate = Convert.ToDateTime(Console.ReadLine()).Date;
                                CourseManager.CourseSchedule(courseID, startDate, endDate);
                                break;

                            }
                        case "30":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine($"Course: {course.Title} starts at {course.StartDate} and ends at {course.EndDate}");
                                }
                                break;
                            }
                        case "31":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course.Id + "--" + course.Title);
                                }
                                Console.Write("Choose the Course to update the schedule(id): ");
                                int courseID = Convert.ToInt32(Console.ReadLine());
                                Console.Write("When will start finally?: ");
                                DateTime startDate = Convert.ToDateTime(Console.ReadLine()).Date;
                                Console.Write("And when will end?: ");
                                DateTime endDate = Convert.ToDateTime(Console.ReadLine()).Date;
                                CourseManager.CourseSchedule(courseID, startDate, endDate);
                                break;
                            }
                        case "32":
                            {
                                Console.Clear();
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course.Id + "--" + course.Title);
                                }
                                Console.Write("Which Cousre Schedule you want to delete?:");
                                int courseId = Convert.ToInt32(Console.ReadLine());
                                CourseManager.DeleteCourse(courseId);
                                break;
                            }

                        case "0":
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    

        public static void MainMenuStudent()
        {
            Student student = new Student();
            bool login = false;
            while (true)
            {

                while (login == false)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    student = StudentManager.FindPassword(username);
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    if (student == null)
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                    else if (SecurePasswordHasher.Verify(password, student.Password) == true)
                    {
                        Console.WriteLine("Successfull login\n");
                        login = true;
                    }
                    else
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                }
                int studentId = student.Id;
                
                
                
                    Console.Clear();
                    Console.WriteLine("1. Enroll to a Course");
                    Console.WriteLine("2. Submit Assignment");
                    Console.WriteLine("3. See daily Schedule");
                    Console.WriteLine("4. Submission Days for each Assignment");
                    Console.WriteLine("0. Exit.");

                    string choise = Console.ReadLine();

                    switch (choise)
                    {
                        case "1":
                            {
                                foreach (var course in CourseManager.GetAllCourses())
                                {
                                    Console.WriteLine(course);
                                }
                                Console.Write("Choose the Course(by id) you want to enroll: ");
                                int courseId = Convert.ToInt32(Console.ReadLine());
                                StudentCourseManager.CreateStudentCourse(studentId, courseId);
                                break;
                            }
                        case "2":
                            {
                            Console.WriteLine("Select an Assignment to submit: ");
                            int assignmentId = Convert.ToInt32(Console.ReadLine());
                            StudentAssignmentManager.SubmitAnAssignment(studentId, assignmentId);
                            Console.WriteLine($"Assignment with Id{assignmentId} is now submitted!");
                            break;
                            }
                        case "3":
                            {
                            Console.WriteLine("Insert a date to see your Schedule: ");
                            DateTime yourDate = Convert.ToDateTime(Console.ReadLine()).Date;
                            StudentCourseManager.GetCoursesPerStudentWithDate(studentId, yourDate);
                            break;
                            }
                        case "4":
                            {
                            StudentAssignmentManager.DaysUntillSubmission(studentId);
                            break;
                            }
                        case "0":
                            {
                                Environment.Exit(0);
                                break;
                            }

                    
                    

                    }
            }
        }

        public static void MainMenuTrainer()
        {
            Trainer trainer = new Trainer();
            bool login = false;
            while (true)
            {

                while (login == false)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    trainer = TrainerManager.FindPassword(username);
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    if (trainer == null)
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                    else if (SecurePasswordHasher.Verify(password, trainer.Password) == true)
                    {
                        Console.WriteLine("Successfull login\n");
                        login = true;
                    }
                    else
                    {
                        Console.WriteLine("\nError: Username and Password do not match\n");
                    }
                }
                int trainerId = trainer.Id;
                while (true)
                {

                    Console.Clear();
                    Console.WriteLine("1. View Courses");
                    Console.WriteLine("2. View Students per Course");
                    Console.WriteLine("3. View assignments per Student per Course");
                    Console.WriteLine("4. Mark assignments per Student per Course");
                    Console.WriteLine("0. Exit");

                    string choise = Console.ReadLine();
                    switch (choise)
                    {
                        case "1":
                            {
                                TrainerCourseManager.GetCoursesPerTrainer(trainerId);
                                Console.ReadLine();
                                break;

                            }
                        case "2":
                            {
                                List<Student> students = TrainerCourseManager.GetAllStudentsPerCourse(trainerId);
                                foreach (var student in students)
                                {
                                    Console.WriteLine(student);
                                }
                                Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                List<Assignment> assignments = TrainerCourseManager.GetAssignmentsPerStudentPerCourse(trainerId);
                                foreach (var assignment in assignments)
                                {
                                    Console.WriteLine(assignment);
                                }
                                Console.ReadLine();
                                break;
                            }
                        case "4":
                            {
                                List<Assignment> assignments = TrainerCourseManager.GetAssignmentsPerStudentPerCourse(trainerId);
                                using (SchoolContext db = new SchoolContext())
                                {
                                    foreach (var ass in assignments)
                                    {
                                        Console.WriteLine("Give your mark for the first assignment: ");
                                        ass.OralMark = Convert.ToInt32(Console.ReadLine());
                                    }
                                    db.SaveChanges();
                                }
                                break;
                            }
                        case "0":
                            {
                                Environment.Exit(0);
                                break;
                            }

                    }
                }
            }
        }
    }
}
