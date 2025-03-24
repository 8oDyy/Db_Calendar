using BOULICAUT_RAFFORT_Calendar.Controllers;
using BOULICAUT_RAFFORT_Calendar.Models;

namespace BOULICAUT_RAFFORT_Calendar.Views;

public partial class AddTaskPage : ContentPage
{
    private readonly TodoController _todoController;
    private List<Evenement> _evenements = new();

    public AddTaskPage(TodoController todoController)
    {
        InitializeComponent();
        _todoController = todoController;
        ChargerEvenements();
    }

    private async void ChargerEvenements()
    {
        _evenements = await _todoController.GetAllEventsAsync();
        foreach (var evt in _evenements)
        {
            EvenementPicker.Items.Add(evt.Nom);
        }
    }

    private async void OnAjouterClicked(object sender, EventArgs e)
    {
        var titre = TitreEntry.Text;
        var nomNouveauEvt = NouvelEvenementEntry.Text;
        int? evenementId = null;

        // Créer un événement s’il est saisi
        if (!string.IsNullOrWhiteSpace(nomNouveauEvt))
        {
            var nouvelEvt = await _todoController.CreerEvenementAsync(nomNouveauEvt);
            evenementId = nouvelEvt.Id;
        }
        else if (EvenementPicker.SelectedIndex >= 0)
        {
            evenementId = _evenements[EvenementPicker.SelectedIndex].Id;
        }

        if (!string.IsNullOrWhiteSpace(titre) && evenementId != null)
        {
            await _todoController.CreerTaskAsync(titre, evenementId.Value);
            await DisplayAlert("Succès", "Tâche ajoutée !", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Erreur", "Merci de remplir tous les champs nécessaires.", "OK");
        }
    }
}