﻿using DataAccessLayer.Abstarct;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookDal:GenericRepository<Book>,IBookDal
    {

    }
}