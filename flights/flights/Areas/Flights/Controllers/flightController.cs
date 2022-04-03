using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using flightSystem.Services;
using flights.Context;
using flights.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace flights.Areas.Flights.Controllers
{
    [Area("Flights")]

        [Authorize]
    public class flightController : Controller
    {
        countryRepoService countryRepoService = new countryRepoService(new FlightsystemdbContext());
        flightRepoService flightRepoService = new flightRepoService(new FlightsystemdbContext());

        [AllowAnonymous]
        public IActionResult show()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Search()
        {
            //SelectList countries = new SelectList(countryRepoService.GetAll(), "ID", "Name");
            SelectList countries = new SelectList(countryRepoService.GetAll(), "Name", "Name");
            ViewBag.countries = countries;
            ViewBag.trips = null;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Search(IFormCollection SearchForm)
        {
            List<flight> flights = flightRepoService.GetAll();

            string FromCountry = SearchForm["FromCountry"];
            if (FromCountry != "")
                flights = flights.Where(x => x.From == FromCountry).ToList();

            string ToCountry = SearchForm["ToCountry"];
            if (ToCountry != "")
                flights = flights.Where(x => x.To == ToCountry).ToList();

            string arrivalstr = SearchForm["ArrivalTime"];
            if (arrivalstr != "")
            {
                DateTime arrival = DateTime.Parse(SearchForm["ArrivalTime"]);
                flights = flights.Where(x => x.ArrivalTime.Year == arrival.Year && x.ArrivalTime.Month == arrival.Month && x.ArrivalTime.Day == arrival.Day ).ToList();
            }
            string DepartureStr = SearchForm["DepartureTime"];
            if (DepartureStr != "")
            {
                DateTime Departure = DateTime.Parse(SearchForm["DepartureTime"]);
                flights = flights.Where(x => x.DepartureTime.Year == Departure.Year && x.DepartureTime.Month == Departure.Month && x.DepartureTime.Day == Departure.Day).ToList();
            }


            string AvailableSeats = SearchForm["AvailableSeats"];
            if (AvailableSeats == "True")
            {
                flights = flights.Where(x => x.AvailableSeat > 0).ToList();
            }


            ViewBag.trips = flights;
            return View();
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Gallery()
        {
            return View();
        }


    }
}
