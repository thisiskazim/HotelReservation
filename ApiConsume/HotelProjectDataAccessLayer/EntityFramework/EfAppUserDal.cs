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
        public EfAppUserDal(Context context) : base(context)
        {

        }

        public List<AppUser> UserListWithWorkLocation()
        {
          var context=new Context();
            return context.Users.Include(x=>x.WorkLocation).ToList();
        }

       public  List<AppUser> UserListWithWorkLocations()
        {
         var context= new Context();
            var values= context.Users.Include(x => x.WorkLocation).ToList();
            return values; ;
        }

      public int AppUserCount()
        {
            var context = new Context();
            var value=context.Users.Count();
            return value;
        }
    }
}