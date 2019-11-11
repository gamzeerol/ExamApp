using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Abstract
{
    public interface IArticleService
    {
        void Add(Article entity);
        Article GetById(int id);
        List<Article> GetAll(Expression<Func<Exam, bool>> filter = null);
        void AddArticle(List<string> titles, List<string> contents);
    }
}
