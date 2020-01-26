using System.ComponentModel.DataAnnotations;

namespace Calendar.Web.Models
{
    public class SerialForm
    {
        [Required]
        public string? SerialId { get; set; }
    }
}