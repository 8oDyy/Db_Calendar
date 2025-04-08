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

    // Charger tous les événements avec leurs tâches
    public async Task<List<Evenement>> GetAllEventsAsync()
    {
        return await _context.evenements
            .Include(e => e.tasks)
            .ToListAsync();
    }

    // Cocher / décocher une tâche
    public async Task ToggleTaskStatusAsync(int taskId)
    {
        var task = await _context.tasks.FindAsync(taskId);

        if (task != null)
        {
            _context.tasks.Remove(task);
            await _context.SaveChangesAsync();

            // Vérifie si l’événement lié n’a plus de tâches
            var remaining = await _context.tasks
                .CountAsync(t => t.EvenementId == task.EvenementId);

            if (remaining == 0)
            {
                var ev = await _context.evenements.FindAsync(task.EvenementId);
                if (ev != null)
                {
                    _context.evenements.Remove(ev);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

    // Ajouter une tâche à un événement
    public async Task AddTaskToEventAsync(int evenementId, string titre)
    {
        var newTask = new TaskItem
        {
            titre = titre,
            fait = false,
            EvenementId = evenementId
        };

        _context.tasks.Add(newTask);
        await _context.SaveChangesAsync();
    }

    // Ajouter un événement
    public async Task<Evenement> AddEventAsync(string nom)
    {
        var newEvent = new Evenement
        {
            nom = nom
        };

        _context.evenements.Add(newEvent);
        await _context.SaveChangesAsync(); // ⬅️ Nécessaire pour générer l'ID

        // 🔁 Ajouter une tâche par défaut pour éviter suppression immédiate
        var defaultTask = new TaskItem
        {
            titre = "Nouvelle tâche",
            fait = false,
            EvenementId = newEvent.id
        };

        _context.tasks.Add(defaultTask);
        await _context.SaveChangesAsync();

        return newEvent;
    }
}