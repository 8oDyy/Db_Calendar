using BOULICAUT_RAFFORT_Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace BOULICAUT_RAFFORT_Calendar.Controllers;

public class TodoController
{
    private readonly TodoContext _context;

    public TodoController(TodoContext context)
    {
        _context = context;
    }

    // Obtenir toutes les tâches avec leur événement
    public async Task<List<TaskItem>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync(); // sans Include pour éviter le bug de navigation
    }


    // Obtenir toutes les tâches d’un événement spécifique
    public async Task<List<TaskItem>> GetTasksByEventAsync(int evenementId)
    {
        return await _context.Tasks
            .Where(t => t.EvenementId == evenementId)
            .ToListAsync();
    }

    // Obtenir la liste des événements (pour les grouper ou les afficher)
    public async Task<List<Evenement>> GetAllEventsAsync()
    {
        return await _context.Evenements
            .Include(e => e.Tasks)
            .ToListAsync();
    }

    // Marquer une tâche comme faite ou non
    public async Task ToggleTaskDoneAsync(int taskId)
    {
        var task = await _context.Tasks.FindAsync(taskId);
        if (task != null)
        {
            task.Fait = !task.Fait;
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<Evenement> CreerEvenementAsync(string nom)
    {
        var evt = new Evenement { Nom = nom };
        _context.Evenements.Add(evt);
        await _context.SaveChangesAsync();
        return evt;
    }

    public async Task CreerTaskAsync(string titre, int evenementId)
    {
        var task = new TaskItem
        {
            Titre = titre,
            EvenementId = evenementId,
            Fait = false
        };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

}