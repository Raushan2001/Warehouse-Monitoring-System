using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WarehouseMonitoring.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Room Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Is Use")]
        public bool? IsRoomUse { get; set; } = false;
    }
}
