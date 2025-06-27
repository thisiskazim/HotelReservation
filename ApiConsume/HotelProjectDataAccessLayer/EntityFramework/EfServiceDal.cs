using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProjectDataAccessLayer.Abstract;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;

namespace HotelProjectDataAccessLayer.EntityFramework
{
    public class EfServiceDal :GenericRepository<Service>,IServicesDal
    {

            private readonly Context _context;

            public EfServiceDal(Context context) : base(context)
            {
                _context = context;
            }
    }
}
