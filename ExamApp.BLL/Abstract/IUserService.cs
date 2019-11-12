using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Abstract
{
   public interface IUserService
    {
        void Add(User entity);
        User GetById(int id);
        void Delete(User entity);
        List<User> GetAll(Expression<Func<Exam, bool>> filter = null);
    }
}
