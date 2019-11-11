using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Abstract
{
    public interface IExamService
    {
        void Add(Exam entity);  
        void Delete(Exam entity);
        Exam GetById(int id);   
        List<Exam> GetAll(Expression<Func<Exam, bool>> filter = null);
        int AddExam(Exam entity);
    }
}
