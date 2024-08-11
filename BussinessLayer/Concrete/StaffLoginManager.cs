using BussinessLayer.Abstract;
using DataAccessLayer.Abstarct;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class StaffLoginManager:IStaffLoginService
    {
        IStaffDal _staffDal;

        public StaffLoginManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public Staff GetStaff(string Gmail, string Password)
        {
            return _staffDal.Get(x=> x.Gmail == Gmail && x.Password == Password);
        }
    }
}
