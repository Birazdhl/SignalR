using SignalRImplementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRImplementation.Repository
{
    public interface ISeatBookingService
    {
        Task<List<SeatBooking>> GetSeatBooking();
        bool UpdateSeatBooking(string ids);
        bool ResetSeatBooking();
    }
}
