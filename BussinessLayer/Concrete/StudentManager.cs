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
    public class StudentManager : IStudentService
    {
        IStudentDal _StudentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _StudentDal = studentDal;
        }

        public Student GetById(int id)
        {
            return _StudentDal.Get(x=>x.StudentId==id);
        }

        public List<Student> GetStudentlist()
        {
            return _StudentDal.List();
        }

        public void StudentAdd(Student student)
        {
            _StudentDal.Insert(student);
        }

        public void StudentDelete(Student student)
        {
            _StudentDal.Delete(student);
        }

        public void StudentUpdate(Student student)
        {
            _StudentDal.Update(student);
        }
    }
}
