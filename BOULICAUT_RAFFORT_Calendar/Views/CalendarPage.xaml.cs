using System.Globalization;
using Microsoft.Maui.Controls.Shapes;
using BOULICAUT_RAFFORT_Calendar.Models;
using BOULICAUT_RAFFORT_Calendar.Services;


namespace BOULICAUT_RAFFORT_Calendar.Views
{
    public partial class CalendarPage : ContentPage
    {
        private DateTime _currentDate;
        private List<GoogleCalendarEvent> _events = new();

        public CalendarPage()
        {
            InitializeComponent();
            _currentDate = DateTime.Now;
            _ = LoadCalendar();
        }

        private async Task LoadCalendar()
        {
            CalendarGrid.Children.Clear();

            // Chargement des événements depuis Google Calendar
            var service = new GoogleCalendarService();
            _events = await service.GetUpcomingEventsAsync();

            var firstDayOfMonth = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
            int startDayOfWeek = ((int)firstDayOfMonth.DayOfWeek + 6) % 7; // Lundi = 0

            MonthLabel.Text = _currentDate.ToString("MMMM yyyy", CultureInfo.GetCultureInfo("fr-FR"));

            int row = 0;
            int col = startDayOfWeek;

            for (int day = 1; day <= daysInMonth; day++)
            {
                var currentDate = new DateTime(_currentDate.Year, _currentDate.Month, day);
                var eventsOfDay = _events.Where(e => e.Start.Date == currentDate.Date).ToList();

                var dayLayout = new VerticalStackLayout
                {
                    Spacing = 2,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                dayLayout.Children.Add(new Label
                {
                    Text = day.ToString(),
                    FontSize = 14,
                    TextColor = Colors.Black,
                    HorizontalOptions = LayoutOptions.Center
                });

                if (eventsOfDay.Any())
                {
                    var dotsLayout = new HorizontalStackLayout
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        Spacing = 3
                    };

                    foreach (var _ in eventsOfDay)
                    {
                        dotsLayout.Children.Add(new BoxView
                        {
                            Color = Colors.DarkOrange,
                            WidthRequest = 6,
                            HeightRequest = 6,
                            CornerRadius = 3
                        });
                    }

                    dayLayout.Children.Add(dotsLayout);
                }

                var border = new Border
                {
                    Background = new SolidColorBrush(Color.FromArgb("#F2F2F2")),
                    Stroke = Colors.LightGray,
                    StrokeThickness = 1,
                    StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(8) },
                    Content = dayLayout,
                    Padding = 5
                };

                var tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += (s, e) => OnDayTapped(currentDate, eventsOfDay);
                border.GestureRecognizers.Add(tapGesture);

                Grid.SetColumn(border, col);
                Grid.SetRow(border, row);
                CalendarGrid.Children.Add(border);

                col++;
                if (col > 6)
                {
                    col = 0;
                    row++;
                }
            }
        }

        private async void OnPreviousMonthClicked(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(-1);
            await LoadCalendar();
        }

        private async void OnNextMonthClicked(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            await LoadCalendar();
        }

        private async void OnDayTapped(DateTime date, List<GoogleCalendarEvent> eventsOfDay)
        {
            if (!eventsOfDay.Any())
                return;

            string message = string.Join("\n", eventsOfDay.Select(e => $"{e.Summary} ({e.Start:HH:mm})"));

            await DisplayAlert($"Événements du {date:dd MMMM yyyy}", message, "OK");
        }
        
        
    }
}












