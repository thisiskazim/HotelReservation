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
   public  class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {

        private readonly Context _context;

        public EfTestimonialDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}
