using ExamApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ExamAppDbContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(Users);
                }
                context.SaveChanges();
            }
        }

        private static User[] Users =
        {
            new User(){ UserName="admin",Password="123"},
            new User(){UserName="admin2",Password="123"}
        };
    }
}
