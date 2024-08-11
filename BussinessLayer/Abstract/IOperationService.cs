using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IOperationService
    {
        List<Operation> GetOperationlist();
        void OperationAdd(Operation operation);
        void OperationUpdate(Operation operation);
        Operation GetById(int id);
        List<Operation> GetStudentList(int id);
        List<Operation> GetStaffList(int id);
        List<Operation> GetWaitList(int id);
    }
}
