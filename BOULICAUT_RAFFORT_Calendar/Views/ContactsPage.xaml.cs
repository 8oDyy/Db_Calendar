using BOULICAUT_RAFFORT_Calendar.Controllers;
using BOULICAUT_RAFFORT_Calendar.Models;

namespace BOULICAUT_RAFFORT_Calendar.Views;

public partial class ContactsPage : ContentPage
{
    private readonly ContactsController _contactsController;

    public ContactsPage(ContactsController contactsController)
    {
        InitializeComponent();
        _contactsController = contactsController;

        // Chargement initial
        LoadContacts();
    }

    private async void LoadContacts()
    {
        try
        {
            var contacts = await _contactsController.GetAllContactsAsync();
            ContactsCollectionView.ItemsSource = contacts;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Impossible de charger les contacts : {ex.Message}", "OK");
        }
    }
}