using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WarehouseMonitoring.Models
{
    public class CroupType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Harvest Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Minimum Storage Life (Days)")]
        public int MinStorageLife { get; set; }
        [Required]
        [DisplayName("Maximum Storage Life (Days)")]
        public int MaxStorageLife { get; set; }
        [Required]
        [DisplayName("Freezing Point (°C)")]
        public double FreezingPoint { get; set; }
        [Required]
        [Range(-50, 50)]
        [DisplayName("Minimum Temperature (°C)")]
        public double MinTemperature { get; set; }
        [Required]
        [Range(-50, 50)]
        [DisplayName("Maximum Temperature (°C)")]
        public double MaxTemperature { get; set; }
        [Required]
        [Range(0, 100)]
        [DisplayName("Minimum Relative Humidity (%)")]
        public int MinHumidity { get; set; }
        [Required]
        [Range(0, 100)]
        [DisplayName("Maximum Relative Humidity (%)")]
        public int MaxHumidity { get; set; }
    }
}
