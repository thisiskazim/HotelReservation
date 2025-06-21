using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebUI.ViewComponents.Default
{
    public class _RezervationPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
