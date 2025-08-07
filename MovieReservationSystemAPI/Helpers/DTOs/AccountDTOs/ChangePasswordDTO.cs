using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.AccountDTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
