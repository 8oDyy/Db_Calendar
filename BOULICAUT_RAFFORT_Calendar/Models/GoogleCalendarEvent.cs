namespace BOULICAUT_RAFFORT_Calendar.Models
{
    public class GoogleCalendarEvent
    {
        public string Summary { get; set; } = "";
        public DateTime Start { get; set; } // utilisé pour placer l’événement dans le bon jour
    }
}