namespace MovieReservationSystemAPI.Helpers.DTOs.TheaterDTOs
{
    public class UpdateTheaterDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<MovieSchedule> MovieSchedules { get; set; }
    }
}
