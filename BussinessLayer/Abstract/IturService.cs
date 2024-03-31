using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IturService
    {
        List<tur> GetturList();
        void turAdd(tur tur);
    }
}
