using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.BLL.Abstract
{
   public interface IUserService
    {
        User HasUser(string UserName, string Password);
    }
}
