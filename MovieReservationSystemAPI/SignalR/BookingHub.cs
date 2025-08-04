using Microsoft.AspNetCore.SignalR;

namespace MovieReservationSystemAPI.SignalR
{
    public class BookingHub : Hub
    {
        public async Task JoinGroup(Guid MovieScheduleId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"MovieSchedule:{MovieScheduleId}");
        }
        public async Task LeaveGroup(Guid MovieScheduleId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"MovieSchedule:{MovieScheduleId}");
        }
    }
}