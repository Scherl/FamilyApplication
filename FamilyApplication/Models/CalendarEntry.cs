using System.ComponentModel.DataAnnotations;

namespace FamilyApplication.Models
{
    public class CalendarEntry
    {
        [Key]
        public Guid CalendarId { get; set; }
        [Required]
        public string EntryTitle { get; set; }
        public string? Location { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public string? Notes { get; set; }
        public int? RecurrenceInDays { get; set; }
        [Required]
        public string CreatedBy { get; set; }


        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
