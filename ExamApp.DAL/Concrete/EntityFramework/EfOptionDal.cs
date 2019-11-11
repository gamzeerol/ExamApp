using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public class EfOptionDal : EfCoreGenericRepository<Option, ExamAppDbContext>, IOptionDal
    {
    }
}
