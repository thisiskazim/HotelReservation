using HotelProjectDataAccessLayer.Abstract;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace HotelProjectDataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        private readonly Context _context;

        public EfAppUserDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<AppUser> UserListWithWorkLocation()
        {
            return _context.Users.Include(x => x.WorkLocation).ToList();
        }

        public List<AppUser> UserListWithWorkLocations()
        {
            return _context.Users.Include(x => x.WorkLocation).ToList();
        }

        public int AppUserCount()
        {
            return _context.Users.Count();
        }
    }
}