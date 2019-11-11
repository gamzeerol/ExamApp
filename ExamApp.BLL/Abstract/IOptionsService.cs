using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Abstract
{
    public interface IOptionsService
    {
        void Add(Option entity);
        void Delete(Option entity);
        Option GetById(int id);
        List<Option> GetAll(Expression<Func<Option, bool>> filter = null);
        int AddExam(Exam entity);
    }
}
