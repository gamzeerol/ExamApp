using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.DAL.Abstract
{
    public interface IExamDal : IRepository<Exam>
    {
        int AddExam(Exam entity);
    }
}
