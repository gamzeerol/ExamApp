using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.DAL.Abstract
{
    public interface IArticleDal:IRepository<Article>
    {
        void AddArticle( List<string> titles,List<string> contents);  //Ekle

    }
}
