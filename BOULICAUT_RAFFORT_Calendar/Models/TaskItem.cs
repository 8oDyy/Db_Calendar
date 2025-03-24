namespace BOULICAUT_RAFFORT_Calendar.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public bool Fait { get; set; }
    public DateTime? Date_Echeance { get; set; }

    // Lien vers l'événement
    public int EvenementId { get; set; }
    //public Evenement Evenement { get; set; }
}