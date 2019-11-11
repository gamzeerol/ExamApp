using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.DAL.Abstract
{
    public interface IQuestionDal : IRepository<Question>
    {
        int AddQuestion(Question entity);
    }
}
