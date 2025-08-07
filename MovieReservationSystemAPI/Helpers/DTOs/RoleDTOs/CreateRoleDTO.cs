using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.RoleDTOs
{
    public class CreateRoleDTO
    {
        [Required]
        public string RoleName { get; set; }
    }
}
