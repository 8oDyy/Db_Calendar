namespace BOULICAUT_RAFFORT_Calendar;
using BOULICAUT_RAFFORT_Calendar.Views;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Enregistrement des routes (optionnel mais recommandé)
        Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
    }
}