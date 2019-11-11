using ExamApp.BLL.Abstract;
using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Concrete
{
    public class OptionManager : IOptionsService
    {
        private IOptionDal _optionDal;

        public OptionManager(IOptionDal optionDal)
        {
            _optionDal = optionDal;
        }


        public void Add(Option entity)
        {
            _optionDal.Add(entity);
        }

        public int AddExam(Exam entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Option entity)
        {
            _optionDal.Delete(entity);
        }

        public List<Option> GetAll(Expression<Func<Option, bool>> filter = null)
        {
            return _optionDal.GetAll();
        }

        public Option GetById(int id)
        {
            return _optionDal.GetById(id);
        }
    }
}
