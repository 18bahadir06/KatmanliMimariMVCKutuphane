using BussinessLayer.Abstract;
using DataAccessLayer.Abstarct;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class GenreManager : IGenreService
    {
        IGenreDal _GenreDal;
        public GenreManager(IGenreDal GenreDal) 
        {
            _GenreDal = GenreDal;
        }
        public void GenreAdd(Genre genre)
        {
            _GenreDal.Insert(genre);
        }

        public void GenreDelete(Genre Genre)
        {
            _GenreDal.Delete(Genre);
        }

        public void GenreUpdate(Genre Genre)
        {
            _GenreDal.Update(Genre);
        }

        public Genre GetByID(int id)
        {
            return _GenreDal.Get(x => x.GenreId == id);
        }

        public List<Genre> GetGenreList()
        {
            return _GenreDal.List();
        }
    }
}
