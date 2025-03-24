using BOULICAUT_RAFFORT_Calendar.Controllers;
using BOULICAUT_RAFFORT_Calendar.Models;

namespace BOULICAUT_RAFFORT_Calendar.Views;

public partial class TodoPage : ContentPage
{
    private readonly TodoController _todoController;

    public TodoPage(TodoController todoController)
    {
        InitializeComponent();
        _todoController = todoController;
        LoadTasks();
    }

    private async void LoadTasks()
    {
        try
        {
            var tasks = await _todoController.GetAllTasksAsync();
            TodoCollectionView.ItemsSource = tasks;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Impossible de charger les tâches : {ex.Message}", "OK");
            System.Diagnostics.Debug.WriteLine($"[ERREUR LoadTasks] {ex}");
        }
    }

    private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkbox && checkbox.BindingContext is TaskItem task)
        {
            await _todoController.ToggleTaskDoneAsync(task.Id);
        }
    }
    
    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTaskPage(_todoController));
    }

}