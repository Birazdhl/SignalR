using Microsoft.AspNetCore.SignalR;
using SignalRHandler.ClinetCommunication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalRHandler.Services
{
    public class SignalRService : ISignalRHubService
    {
        private readonly IHubContext<SignalRClientHub> _hubContext;

        public SignalRService(IHubContext<SignalRClientHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        public async Task<bool> BookTheRespectiveTickets(string ids)
        {
            ids = "#" + ids;
            ids = ids.Replace(",", ",#");
            await this._hubContext.Clients.All.SendAsync("BookRespectiveTickets", ids);
            return true;
        }

        public async Task<bool> ResetAllSeats()
        {
            await this._hubContext.Clients.All.SendAsync("ResetAllTickets");
            return true;
        }
    }
}
