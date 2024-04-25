using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IGenreService
    {
        List<Genre> GetGenreList();
        void GenreAdd(Genre genre);
        Genre GetByID(int id);
        void GenreDelete (Genre Genre);
        void GenreUpdate (Genre Genre);
    }
}
