using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IStaffService
    {
        List<Staff> GetStaffList();
        void StaffAdd(Staff staff);
        void StaffUpdate(Staff staff);
        void StaffDelete(Staff staff);
        Staff GetById(int id);
        bool AdminControl(int id);
    }
}
