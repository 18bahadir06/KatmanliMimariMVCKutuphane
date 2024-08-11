using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IBookService
    {
        List<Book> GetBookList();
        List<Book> GetGenreBookList(int id);
        List<Book> GetAuthorBookList(int id);
        void BookAdd(Book book);
        void BookUpdate(Book book);
        void BookDelete(Book book);
        Book GetById(int id);
    }
}
