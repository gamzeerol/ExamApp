using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public class EfUserDal : EfCoreGenericRepository<User,ExamAppDbContext>,IUserDal
    {
        
    }
}
