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
        private readonly Context _context;

        public EfMessageCategoryDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}

