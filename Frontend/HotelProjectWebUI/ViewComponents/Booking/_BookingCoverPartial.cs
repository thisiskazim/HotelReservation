using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace HotelProjectWebUI.ViewComponents.Booking
{
    public class _BookingCoverPartial    :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
