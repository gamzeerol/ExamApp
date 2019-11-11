using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public class EfExamDal : EfCoreGenericRepository<Exam, ExamAppDbContext>, IExamDal
    {
        

        public int AddExam(Exam entity)
        {
            using (var _context = new ExamAppDbContext())
            {
                _context.Add(entity);
                _context.SaveChanges();
                return entity.ExamId;

            }
        }
    }
}
