using DataAccessLayer.Concrete.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class turManager
    {
        GenericRepository<tur> repo =new GenericRepository<tur>();

        public List<tur> GetAll()
        {
            return repo.GetList();
        }
        public void turAddBL(tur item)
        {
            if(item.ad=="" || item.ad.Length<=3)
            {
                //hata mesajı

            }
            else
            {
                repo.Insert(item);
            }
        }
    }
}
