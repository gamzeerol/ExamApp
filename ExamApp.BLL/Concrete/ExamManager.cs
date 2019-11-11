using ExamApp.BLL.Abstract;
using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Concrete
{
    public class ExamManager : IExamService
    {
        private IExamDal _examDal;

        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }
        public void Add(Exam entity)
        {
           _examDal.Add(entity);
        }

        public int AddExam(Exam entity)
        {
            return _examDal.AddExam(entity);
        }

        public void Delete(Exam entity)
        {
            _examDal.Delete(entity);
        }

        public List<Exam> GetAll(Expression<Func<Exam, bool>> filter = null)
        {
            return _examDal.GetAll();
        }

        public Exam GetById(int id)
        {
            return _examDal.GetById(id);
        }
    }
}
