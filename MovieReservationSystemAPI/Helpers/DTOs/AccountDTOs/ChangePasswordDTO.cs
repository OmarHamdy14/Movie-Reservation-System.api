namespace MovieReservationSystemAPI.Helpers.DTOs.AccountDTOs
{
    public class ChangePasswordDTO
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
