namespace BOULICAUT_RAFFORT_Calendar.Models;

public class Evenement
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public DateTime Date_Creation { get; set; }

    // Navigation vers les tâches liées
    public ICollection<TaskItem> Tasks { get; set; }
}