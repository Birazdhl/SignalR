using Dapper;
using SignalRImplementation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRImplementation.Repository
{
    public class SeatBookingService : ISeatBookingService
    {
        public IDbConnection db = new SqlConnection(DapperORM.connectionString);
        public async Task<List<SeatBooking>> GetSeatBooking()
        {
            string strSQL = @"Select * From SeatBooking";
            List<SeatBooking> seatList = new List<SeatBooking>();
            seatList = db.Query<SeatBooking>(strSQL).ToList();
            return seatList;
        }

        public bool UpdateSeatBooking(string ids)
        {
            string strSQL = $@"Update SeatBooking SET Name = 'booked' WHERE ID IN ({ids})";
            db.Query<bool>(strSQL);
            return true;
        }

        public bool ResetSeatBooking()
        {
            string strSQL = @"Update SeatBooking SET Name = '' ";
            db.Query<bool>(strSQL);
            return true;
        }
    }
}
