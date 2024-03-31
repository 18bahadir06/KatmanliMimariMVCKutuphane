using BussinessLayer.Abstract;
using DataAccessLayer.Abstarct;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class turManager : IturService
    {
        IturDal _turdal;

        public turManager(IturDal turdal)
        {
            _turdal = turdal;
        }

        public List<tur> GetturList()
        {
            return _turdal.List(); 
        }

        public void turAdd(tur tur)
        {
            _turdal.Insert(tur);
        }
    }
}
