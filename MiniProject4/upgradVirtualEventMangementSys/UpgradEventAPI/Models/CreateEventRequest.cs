namespace UpgradEventAPI.Models
{
    public class CreateEventRequest
    {
        public string EventName { get; set; } //DTOs
        public string EventCategory { get; set; }
        public string EventDate { get; set; }   // string
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
