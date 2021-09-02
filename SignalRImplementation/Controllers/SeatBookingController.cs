using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRImplementation.Controllers
{
    public class SeatBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
