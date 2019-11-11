using ExamApp.BLL.Abstract;
using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }
        public void Add(Question entity)
        {
            _questionDal.Add(entity);
        }

        public int AddQuestion(Question entity)
        {
            return _questionDal.AddQuestion(entity);
        }

        public void Delete(Question entity)
        {
            _questionDal.Delete(entity);
        }

        public List<Question> GetAll(Expression<Func<Exam, bool>> filter = null)
        {
            return _questionDal.GetAll();
        }

        public Question GetById(int id)
        {
            return _questionDal.GetById(id);
        }
    }
}
