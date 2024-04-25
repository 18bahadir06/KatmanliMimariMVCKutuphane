using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstarct
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T item);
        //tek değer döndürmesi için misal ıd si 1 olan
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T item);
        void Update(T item);
        //ismi ahmet olanlar gibi
        List<T> ListFiltr(Expression<Func<T,bool>> filter);
    }
}
