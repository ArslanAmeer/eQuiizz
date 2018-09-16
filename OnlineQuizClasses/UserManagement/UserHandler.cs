using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectClasses.UserMgment
{
    public class UserHandler
    {
        public User GetUser(string Loginid, string Password)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from v in db.Users where v.Loginid.Equals(Loginid) && v.Password.Equals(Password) select v).FirstOrDefault();
            }
        }
        public List<User> GetUsers()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from u in db.Users
                        .Include(m => m.Role)
                        .Include(m => m.Gender)
                        select u).ToList();
            }
        }

        public User GetUser(int id)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from u in db.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            }
        }

        public List<Gender> GetGender()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Genders select c).ToList();
            }
        }
        public User GetUserById(int id)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Users
                        .Include(x => x.Role)
                        .Include(x => x.Gender)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
    }
}
