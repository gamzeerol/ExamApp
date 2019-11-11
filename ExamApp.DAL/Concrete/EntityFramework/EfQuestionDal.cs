using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.DAL.Concrete.EntityFramework
{
    public class EfQuestionDal : EfCoreGenericRepository<Question, ExamAppDbContext>, IQuestionDal
    {
        public int AddQuestion(Question entity)
        {
            using (var context=new ExamAppDbContext())
            {
                context.Set<Question>().Add(entity);
                context.SaveChanges();
                return entity.QuestionId;
            }
        }
    }
}
