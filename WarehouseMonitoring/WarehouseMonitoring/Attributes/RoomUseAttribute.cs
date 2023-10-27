using Microsoft.Build.Execution;
using System.ComponentModel.DataAnnotations;
using WarehouseMonitoring.Context;

namespace WarehouseMonitoring.Attributes
{
    public class IsRoomUse : ValidationAttribute
    {
        
        public override string FormatErrorMessage(string name)
        {
            return "This Room is already used";
        }

        protected override ValidationResult IsValid(object objValue, ValidationContext validationContext)
        {

            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var item = _context?.Harvests.Where(x => x.RoomId == (int)objValue).ToList();

            if (item?.Count > 0)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}
