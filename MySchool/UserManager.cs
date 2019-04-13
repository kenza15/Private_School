using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchool.Models;

namespace MySchool
{
    static public class UserManager
    {
        static public void CreateUser(string username, string password)
        {
            using (SchoolContext db = new SchoolContext())
            {
                User user = new User()
                {
                    Username = username,
                    Password = password,
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static User FindPassword(string username)
        {
            using (SchoolContext db = new SchoolContext())
            {
                var query = db.Users.Where(s => s.Username == username).FirstOrDefault<User>();
                return query;
            }
        }

        public static int getCountOfUsers (){
            List<User> users = new List<User>();
            using (SchoolContext db = new SchoolContext())
            {
                users = db.Users.ToList();
            }
            return users.Count();
        }
    }
}
