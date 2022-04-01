using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace flights.Areas.Flights.Controllers
{
    [Area("Flights")]

    [Authorize]

    public class flightController : Controller
    {
        [AllowAnonymous]
        public IActionResult show()
        {
            return View();
        }
  
        public IActionResult Booking()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }
     
    }
}
