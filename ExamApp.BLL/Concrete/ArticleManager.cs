using ExamApp.BLL.Abstract;
using ExamApp.DAL.Abstract;
using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.BLL.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
;
        }
        public void Add(Article entity)
        {
            _articleDal.Add(entity);
        }

        public void AddArticle(List<string> titles, List<string> contents)
        {
            _articleDal.AddArticle(titles, contents);
        }

        public List<Article> GetAll(Expression<Func<Exam, bool>> filter = null)
        {
          return _articleDal.GetAll();
        }

        public Article GetById(int id)
        {
            return _articleDal.GetById(id);
        }
    }
}
