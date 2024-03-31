using DataAccessLayer.Abstarct;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfturDal:GenericRepository<tur>,IturDal
    {

    }
}
