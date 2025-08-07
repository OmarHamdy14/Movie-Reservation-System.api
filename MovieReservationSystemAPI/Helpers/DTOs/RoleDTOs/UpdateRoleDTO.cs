using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.RoleDTOs
{
    public class UpdateRoleDTO
    {
        [Required]
        public string RoleName { get; set; }
    }
}
