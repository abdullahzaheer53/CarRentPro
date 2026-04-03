using CarRentPro.Data;
using CarRentPro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Services
{
    public class HistoryService
    {
        private HistoryRepository historyRepo = new HistoryRepository();
        public object GetHistory()
        {
            var histories = historyRepo.GetHistory();
            return histories.Select(h => new
            {
                h.Id,
                h.BookingId,
                h.UserId,
                h.CarId,
                h.PickupDate,
                h.ReturnDate,
                h.TotalPaid,
                h.CreatedAt
            }).ToList();
        }

        public object GetHistoryById(long id)
        {
            var history = historyRepo.GetHistoryByBookingId(id);
            if (history == null)
                return null;
            return new
            {
                history.Id,
                history.BookingId,
                history.UserId,
                history.CarId,
                history.PickupDate,
                history.ReturnDate,
                history.TotalPaid,
                history.CreatedAt
            };
        }
    }


}