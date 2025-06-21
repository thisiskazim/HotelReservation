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
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public void TDelete(Staff t)
        {
            _staffDal.Delete(t);
        }

       

      
        public void TInsert(Staff t)
        {
            _staffDal.Insert(t);
        }

        

        public void TUpdate(Staff t)
        {
            _staffDal.Update(t);
        }

       public  Staff TGetByID(int id)
        {
            return _staffDal.GetByID(id);
        }

       
          public List<Staff> TGetList()
        {
            return _staffDal.GetList();
        }

        int IStaffService.TGetStaffCount()
        {
            return _staffDal.GetStaffCount();
        }

        List<Staff> IStaffService.TLast4Staff()
        {
           return  _staffDal.Last4Staff();
        }
    }
}
