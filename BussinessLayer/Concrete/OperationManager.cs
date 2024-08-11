using BussinessLayer.Abstract;
using DataAccessLayer.Abstarct;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class OperationManager:IOperationService
    {
        IOperationDal _OperationDal;

        public OperationManager(IOperationDal operationDal)
        {
            _OperationDal = operationDal;
        }

        public Operation GetById(int id)
        {
            return _OperationDal.Get(x => x.OperationId == id);
        }

        public List<Operation> GetDelayList()
        {
            return _OperationDal.ListFiltr(x => x.DeliveryStatus == false && x.ReturnDate1 < DateTime.Now) ;
        }

        public List<Operation> GetNoReturnList()
        {
            return _OperationDal.ListFiltr(x=>x.DeliveryStatus==false);
        }

        public List<Operation> GetOperationlist()
        {
            return _OperationDal.List();
        }

        public List<Operation> GetReturnList()
        {
            return _OperationDal.ListFiltr(x=>x.DeliveryStatus==true);
        }

        public List<Operation> GetStaffList(int id)
        {
            return _OperationDal.ListFiltr(x => x.StaffId == id);
        }

        public List<Operation> GetStudentList(int id)
        {
            return _OperationDal.ListFiltr(x=>x.StudentId==id);
        }

        public List<Operation> GetWaitList(int id)
        {
            return _OperationDal.ListFiltr(x => x.StaffId == id && x.DeliveryStatus==false);
        }

        public void OperationAdd(Operation operation)
        {
            _OperationDal.Insert(operation);
        }

        public void OperationUpdate(Operation operation)
        {
            _OperationDal.Update(operation);
        }
    }
}
