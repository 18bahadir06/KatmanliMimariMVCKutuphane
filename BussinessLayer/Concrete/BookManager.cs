using BussinessLayer.Abstract;
using DataAccessLayer.Abstarct;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _BookDal;
        public BookManager(IBookDal BookDal)
        {
            _BookDal = BookDal;
        }
        public void BookAdd(Book book)
        {
            _BookDal.Insert(book);
        }

        public void BookDelete(Book book)
        {
            _BookDal.Delete(book);
        }

        public void BookUpdate(Book book)
        {
            _BookDal.Update(book);
        }

        public List<Book> GetAuthorBookList(int id)
        {
            return _BookDal.ListFiltr(x => x.AuthorId == id);
        }

        public List<Book> GetBookList()
        {
            return _BookDal.List();
        }

        public Book GetById(int id)
        {
            return _BookDal.Get(x=>x.BookId==id);
        }

        public List<Book> GetGenreBookList(int id)
        {
            return _BookDal.ListFiltr(x=>x.GenreId==id);
        }
    }
}
