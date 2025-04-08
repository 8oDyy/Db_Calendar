using System.ComponentModel.DataAnnotations.Schema;
using BOULICAUT_RAFFORT_Calendar.Models;

public class TaskItem
{
    public int id { get; set; }
    public string titre { get; set; } = string.Empty;
    public bool fait { get; set; }

    [Column("evenement_id")]
    public int EvenementId { get; set; }

    public Evenement? evenement { get; set; }
}