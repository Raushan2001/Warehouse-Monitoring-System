using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WarehouseMonitoring.Attributes;

namespace WarehouseMonitoring.Models
{
    public class Harvest
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Harvest Type")]
        public int CroupTypeId { get; set; }
        [DisplayName("Harvest Type")]
        public virtual CroupType? CroupType { get; set; }

        [BindRequired]
        [Required]
        [DisplayName("Room")]
        public int RoomId { get; set; }      
        public virtual Room? Room { get; set; }

        [Required]
        [NotFutureDate]
        [DisplayName("Date and Time of Storage")]
        public DateTime DateOfStorage { get; set; }
        
        
        [DisplayName("Quantity (Kg)")]
        public double Quantity { get; set; }
    }
}
