using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectEntityLayer.Concrete
{
    public abstract class BaseEntity
    {
        [NotMapped] 
        public List<string> ErrorMessages { get; set; } = new();
    }
}
