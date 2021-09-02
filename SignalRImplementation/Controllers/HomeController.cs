using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRHandler.Services;
using SignalRImplementation.Models;
using SignalRImplementation.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRImplementation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISeatBookingService _seatBookingService;
        private readonly ILogger<HomeController> _logger;
        private readonly ISignalRHubService _signalRHubServices;
        public HomeController(ILogger<HomeController> logger, ISeatBookingService seatBookingService, ISignalRHubService signalRHubServices)
        {
            _logger = logger;
            _seatBookingService = seatBookingService;
            _signalRHubServices = signalRHubServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> SeatBooking()
        {
            var result = await _seatBookingService.GetSeatBooking();
            return View(result);
        }

        [HttpGet]
        public IActionResult UpdateSeatBooking(string ids)
        {
            var result = _seatBookingService.UpdateSeatBooking(ids);
            var signalR = _signalRHubServices.BookTheRespectiveTickets(ids);
            return this.RedirectToAction("SeatBooking");
        }

        [HttpGet]
        public IActionResult ResetAllBooking()
        {
            var result = _seatBookingService.ResetSeatBooking();
            var signalR = _signalRHubServices.ResetAllSeats();
            return this.RedirectToAction("SeatBooking");
        }
    }
}
