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
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {

        private readonly Context _context;

        public EfStaffDal(Context context) : base(context)
        {
            _context = context;
        }

        public int GetStaffCount()
        {
            var value = _context.Staffs.Count();      
            return value;

        }

      public List<Staff> Last4Staff()
        {  

            var values=_context.Staffs.OrderByDescending(x=>x.StafID).Take(4).ToList();
            return values;
        }
    }                                                            
}
