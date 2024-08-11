using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IStudentService
    {
        List<Student> GetStudentlist();
        void StudentAdd(Student student);
        void StudentUpdate(Student student);
        void StudentDelete(Student student);
        Student GetById(int id);
    }
}
