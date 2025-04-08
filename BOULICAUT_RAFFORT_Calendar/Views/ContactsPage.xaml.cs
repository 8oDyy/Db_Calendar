using BOULICAUT_RAFFORT_Calendar.Controllers;
using BOULICAUT_RAFFORT_Calendar.Models;

namespace BOULICAUT_RAFFORT_Calendar.Views;

public partial class ContactsPage : ContentPage
{
    private readonly ContactsController _contactsController;
    private List<BOULICAUT_RAFFORT_Calendar.Models.Contact> _allContacts;

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
            _allContacts = await _contactsController.GetAllContactsAsync();
            ContactsCollectionView.ItemsSource = _allContacts;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Impossible de charger les contacts : {ex.Message}", "OK");
        }
    }

    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        var searchText = e.NewTextValue?.ToLower() ?? "";

        if (string.IsNullOrWhiteSpace(searchText))
        {
            ContactsCollectionView.ItemsSource = _allContacts;
        }
        else
        {
            ContactsCollectionView.ItemsSource = _allContacts
                .Where(contact =>
                    contact.Nom?.ToLower().Contains(searchText) == true ||
                    contact.Prenom?.ToLower().Contains(searchText) == true ||
                    contact.Telephone?.ToLower().Contains(searchText) == true ||
                    contact.Email?.ToLower().Contains(searchText) == true)
                .ToList();
        }
    }
}