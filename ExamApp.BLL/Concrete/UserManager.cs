using ExamApp.BLL.Abstract;
using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;      
        }
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }


        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(Expression<Func<Exam, bool>> filter = null)
        {
            return _userDal.GetAll();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
