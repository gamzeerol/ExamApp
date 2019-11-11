using ExamApp.BLL.Abstract;
using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.BLL.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            userDal = _userDal;
        }
        public User HasUser(string UserName, string Password)
        {
           return _userDal.HasUser(UserName, Password);
        }
    }
}
