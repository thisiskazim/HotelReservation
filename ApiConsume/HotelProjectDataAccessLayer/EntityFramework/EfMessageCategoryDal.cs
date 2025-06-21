using HotelProjectDataAccessLayer.Abstract;
using HotelProjectDataAccessLayer.Concrete;
using HotelProjectDataAccessLayer.Repositories;
using HotelProjectEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDataAccessLayer.EntityFramework
{
    public class EfMessageCategoryDal   :GenericRepository<MessageCategory>,IMessageCategoryDal
    {
        public EfMessageCategoryDal(Context context) : base(context)
        {

        }
    }
}

