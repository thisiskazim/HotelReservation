using HotelProjectBusinessLayer.Abstract;
using HotelProjectDataAccessLayer.Abstract;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectBusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetList()
        {
          return _appUserDal.GetList(); 
        }

        public void TInsert(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser t)
        {
            throw new NotImplementedException();
        }

        int IAppUserService.TAppUserCount()
        {
           return _appUserDal.AppUserCount();
        }

        List<AppUser> IAppUserService.TUserListWithWorkLocation()
        {
           return _appUserDal.UserListWithWorkLocation();
        }

        List<AppUser> IAppUserService.TUserListWithWorkLocations()
        {
           return _appUserDal.UserListWithWorkLocations();
        }
    }
}
