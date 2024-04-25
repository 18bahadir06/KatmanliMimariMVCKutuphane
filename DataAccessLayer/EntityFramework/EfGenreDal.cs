using DataAccessLayer.Abstarct;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGenreDal:GenericRepository<Genre>,IGenreDal
    {

    }
}
