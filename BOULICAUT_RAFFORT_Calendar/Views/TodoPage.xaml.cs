using BOULICAUT_RAFFORT_Calendar.Controllers;
using BOULICAUT_RAFFORT_Calendar.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace BOULICAUT_RAFFORT_Calendar.Views;

public partial class TodoPage : ContentPage
{
    private readonly TodoController _controller;

    public ObservableCollection<Evenement> Events { get; set; } = new();

    public TodoPage(TodoController controller)
    {
        InitializeComponent();
        _controller = controller;
        BindingContext = this;

        LoadEvents();
    }

    private async void LoadEvents()
    {
        try
        {
            Events.Clear();
            var eventsFromDb = await _controller.GetAllEventsAsync();
            foreach (var ev in eventsFromDb)
                Events.Add(ev);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Impossible de charger les tâches : {ex.Message}", "OK");
        }
    }

    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkbox && checkbox.BindingContext is TaskItem task && e.Value)
        {
            await _controller.ToggleTaskStatusAsync(task.id);
            LoadEvents(); // Recharge les données
        }
    }

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Evenement evenement)
        {
            string result = await DisplayPromptAsync("Nouvelle tâche", "Nom de la tâche :");

            if (!string.IsNullOrWhiteSpace(result))
            {
                await _controller.AddTaskToEventAsync(evenement.id, result);
                LoadEvents();
            }
        }
    }

    private async void OnAddEventClicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Nouvel événement", "Nom de l'événement :");

        if (!string.IsNullOrWhiteSpace(result))
        {
            await _controller.AddEventAsync(result);
            LoadEvents();
        }
    }
}
