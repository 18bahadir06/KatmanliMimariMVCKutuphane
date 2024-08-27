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
    public class StaffManager:IStaffService
    {
        IStaffDal _StaffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _StaffDal = staffDal;
        }

        public bool AdminControl(int id)
        {
            var a=GetById(id);
            return a.Admin;
        }

        public Staff GetById(int id)
        {
            return _StaffDal.Get(x=>x.StaffId==id);
        }

        public List<Staff> GetStaffList()
        {
            return _StaffDal.List();
        }
        public void StaffAdd(Staff staff)
        {
            _StaffDal.Insert(staff);
        }
        public void StaffDelete(Staff staff)
        {
            _StaffDal.Delete(staff);
        }

        public void StaffUpdate(Staff staff)
        {
            _StaffDal.Update(staff);
        }
    }
}
