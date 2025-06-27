using HotelProjectDataAccessLayer.Abstract;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;
using HotelProjectWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDataAccessLayer.EntityFramework
{
    public class EfWorkLocationDal : GenericRepository<WorkLocation>, IWorkLocationDal
    {

        private readonly Context _context;

        public EfWorkLocationDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}
