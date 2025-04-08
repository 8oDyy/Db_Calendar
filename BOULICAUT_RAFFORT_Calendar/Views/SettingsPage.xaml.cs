using Microsoft.Maui.Storage;

namespace BOULICAUT_RAFFORT_Calendar.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            // Chargement des valeurs sauvegardées
            CalendarIdEntry.Text = Preferences.Get("CalendarID", "fr.french#holiday@group.v.calendar.google.com");
            ContactDbConnectionStringEditor.Text = Preferences.Get("ContactDbConnectionString", "server=172.20.10.12;port=3306;database=contact-db;user=root;password=HBca06022004!;");
            TodoDbConnectionStringEditor.Text = Preferences.Get("TodoDbConnectionString", "server=172.20.10.12;port=3306;database=todo-db;user=root;password=HBca06022004!;");
        }

        private void OnSaveSettingsClicked(object sender, EventArgs e)
        {
            Preferences.Set("CalendarID", CalendarIdEntry.Text);
            Preferences.Set("ContactDbConnectionString", ContactDbConnectionStringEditor.Text);
            Preferences.Set("TodoDbConnectionString", TodoDbConnectionStringEditor.Text);

            DisplayAlert("Succès", "Paramètres sauvegardés avec succès !", "OK");
        }
    }
}