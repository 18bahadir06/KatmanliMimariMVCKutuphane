using BussinessLayer.Abstract;
using DataAccessLayer.Abstarct;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _AuthorDal;

        public AuthorManager(IAuthorDal AuthorDal)
        {
            _AuthorDal = AuthorDal;
        }

        public void AuthorAdd(Author author)
        {
            _AuthorDal.Insert(author);
        }

        public void AuthorDelete(Author author)
        {
            _AuthorDal.Delete(author);
        }

        public void AuthorUpdate(Author author)
        {
            _AuthorDal.Update(author);
        }

        public List<Author> GetAuthorList()
        {
            return _AuthorDal.List();
        }

        public Author GetById(int id)
        {
            return _AuthorDal.Get(x=>x.AuthorId==id);
        }
    }
}
