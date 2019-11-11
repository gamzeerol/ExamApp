using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamApp.DAL.Abstract
{
    public interface IRepository<T> //Tüm Entity'ler için aynı fonksiyonu tekrar tekrar yazmamak için "Generic Architecture" kullandım
    {
        void Add(T entity);  //Ekle
        void Delete(T entity); // Sil
        T GetById(int id);   //Id'ye göre getir
        List<T> GetAll(Expression<Func<T, bool>> filter = null);  // Tümünü getir
                                                                  // GetAll fonksiyonunu çağırırken koşul yazabilmek için 
                                                                  //Expression ifadesini kullandım.

    }
}
