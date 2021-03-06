using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace ApplicationShared
{
    public interface IBooking
    {
        Task<int> CreateReservation(Room selectedRoom, DateTime timestamp, int slot, User user);
        Task<bool> CancelReservation(User user, int Id);
        Task<List<Reservation>> GetUserReservations(User user);
        Task<bool> UpdateReservation(Reservation currReservation,DateTime newTime, int newSlot);
        Task<bool> ComparePrivilege(User userA, User userB);

        (DateTime start, DateTime end) getTimestampsFromTimeslot(int slot, DateTime selectedDay);
    }
}