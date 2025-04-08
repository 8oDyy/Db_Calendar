namespace BOULICAUT_RAFFORT_Calendar.Models;

public class Evenement
{
    public int id { get; set; }
    public string nom { get; set; } = string.Empty;

    public List<TaskItem> tasks { get; set; } = new();
}