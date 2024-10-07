using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class Information
    {
        public Guid Info_id { get; set; } // Primary Key

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty; // Default to empty string

        public DateTime Date { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public bool Confirmation { get; set; } = false; // Default value

        public string? ContactNo { get; set; } // Nullable

        public string? Email { get; set; } // Nullable

        public bool Deleted { get; set; } = false; // Default value

        public string? Feedback { get; set; } // Nullable

        public string? Attachment { get; set; } // Nullable

        public DateTime EntryRecord { get; set; }
    }
}
