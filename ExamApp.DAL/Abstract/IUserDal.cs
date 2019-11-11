using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.DAL.Abstract
{
    public interface IUserDal
    {
        User HasUser(string UserName ,string Password);
    }
}
