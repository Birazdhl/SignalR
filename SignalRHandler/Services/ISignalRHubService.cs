using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalRHandler.Services
{
    public interface ISignalRHubService
    {
        Task<bool> BookTheRespectiveTickets(string ids);
        Task<bool> ResetAllSeats();
    }
}
