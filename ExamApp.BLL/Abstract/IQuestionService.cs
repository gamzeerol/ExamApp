using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Abstract
{
   public interface IQuestionService
    {
        void Add(Question entity);
        int AddQuestion(Question entity);
        Question GetById(int id);
        void Delete(Question entity);
        List<Question> GetAll(Expression<Func<Exam, bool>> filter = null);
    }
}
