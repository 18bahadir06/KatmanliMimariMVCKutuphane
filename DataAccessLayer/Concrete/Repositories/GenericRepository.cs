﻿using DataAccessLayer.Abstarct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c=new Context();
        
        DbSet<T> _object;

        public GenericRepository()
        {
            _object=c.Set<T>();
        }

        public void Delete(T item)
        {
            //var deletedEntity = c.Entry(item);
            //deletedEntity.State = EntityState.Deleted;
            _object.Remove(item);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void Insert(T item)
        {
            _object.Add(item);
            c.SaveChanges();
        }

        public List<T> ListFiltr(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T item)
        {
            var updatedEntity = c.Entry(item);
            updatedEntity.State=EntityState.Modified;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }
    }
}
