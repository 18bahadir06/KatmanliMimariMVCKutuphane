using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAuthorList();
        void AuthorAdd(Author author);
        void AuthorUpdate(Author author);
        void AuthorDelete(Author author);
        Author GetById(int id);
    }
}
