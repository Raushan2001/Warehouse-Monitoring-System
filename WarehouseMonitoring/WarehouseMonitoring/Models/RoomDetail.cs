using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WarehouseMonitoring.Models
{
    public class RoomDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Room")]
        public int RoomId { get; set; }
        public virtual Room? Room { get; set; }
        [Required]
        [Range(-50, 50)]
        [DisplayName("Tempreature (°C)") ]
        public int Tempreature { get; set; }
        [Required]
        [Range(0, 100)]
        [DisplayName("Relative Humidity (%)")]
        public int Humidity { get; set; }

        [DisplayName("Create Date Time")]
        public DateTime? CreateDateTime { get; set; } = DateTime.Now;
    }
}
