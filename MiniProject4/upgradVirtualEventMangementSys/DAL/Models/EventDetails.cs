using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class EventDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Event Name must be under 50 characters")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Event Category is required")]
        [StringLength(50, ErrorMessage = "Category must be under 50 characters")]
        public string EventCategory { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } 
    }
}