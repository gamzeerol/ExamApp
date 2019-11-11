using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        User u;
        public User HasUser(string UserName, string Password)
        {
            using (var context=new ExamAppDbContext())
            {
              u= context.Set<User>().Where(u => u.UserName == UserName && u.Password == Password).SingleOrDefault();
            }
            return u;

        }
    }
}
