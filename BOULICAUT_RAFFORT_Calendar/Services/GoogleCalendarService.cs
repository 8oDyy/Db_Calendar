using System.Net.Http.Json;
using BOULICAUT_RAFFORT_Calendar.Models;
using Microsoft.Maui.Storage;

namespace BOULICAUT_RAFFORT_Calendar.Services
{
    public class GoogleCalendarService
    {
        // Ta clé API Google et ton ID de calendrier
        private const string ApiKey = "AIzaSyCK2fZGRWdjHt_4Yf9vg3lfCXGDHf2HD38";
        string CalendarId = Preferences.Get("CalendarID", "fr.french#holiday@group.v.calendar.google.com");

        

        public async Task<List<GoogleCalendarEvent>> GetUpcomingEventsAsync()
        {
            try
            {
                var now = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ssZ");
                var url = $"https://www.googleapis.com/calendar/v3/calendars/{Uri.EscapeDataString(CalendarId)}/events?key={ApiKey}&timeMin={now}&singleEvents=true&orderBy=startTime&maxResults=2500";

                using var httpClient = new HttpClient();
                var response = await httpClient.GetFromJsonAsync<GoogleCalendarApiResponse>(url);

                if (response?.Items == null)
                    return new List<GoogleCalendarEvent>();

                return response.Items
                    .Where(e => e.Start != null)
                    .Select(e => new GoogleCalendarEvent
                    {
                        Summary = e.Summary ?? "(Sans titre)",
                        Start = e.Start.DateTime ?? DateTime.Parse(e.Start.Date!)
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur Google Calendar : " + ex.Message);
                return new List<GoogleCalendarEvent>();
            }
        }

        // Classes pour désérialiser la réponse JSON de Google Calendar
        private class GoogleCalendarApiResponse
        {
            public List<GoogleApiEvent>? Items { get; set; }
        }

        private class GoogleApiEvent
        {
            public string? Summary { get; set; }
            public GoogleApiDateTime? Start { get; set; }
        }

        private class GoogleApiDateTime
        {
            public string? Date { get; set; }
            public DateTime? DateTime { get; set; }
        }
    }
}

