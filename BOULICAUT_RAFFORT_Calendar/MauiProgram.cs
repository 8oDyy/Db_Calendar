using Microsoft.EntityFrameworkCore;
using BOULICAUT_RAFFORT_Calendar.Models;
using BOULICAUT_RAFFORT_Calendar.Controllers;
using BOULICAUT_RAFFORT_Calendar.Views;

namespace BOULICAUT_RAFFORT_Calendar;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Connexion EF Core à MySQL
        // Connexion pour la base CONTACTS
        var contactDbConnectionString = "server=192.168.1.54;port=3306;database=contact-db;user=root;password=HBca06022004!";
        var contactServerVersion = new MySqlServerVersion(new Version(8, 0, 36));

        // Connexion pour la basetodo
        var todoDbConnectionString = "server=192.168.1.54;port=3306;database=todo-db;user=root;password=HBca06022004!";
        var todoServerVersion = new MySqlServerVersion(new Version(8, 0, 36));

        // ContactsContext
        builder.Services.AddDbContext<ContactsContext>(options =>
        {
            options.UseMySql(contactDbConnectionString, contactServerVersion);
        });
        
        // Enregistrement du contrôleur et de la page pour la page d'ajout de contact
        builder.Services.AddTransient<AddTaskPage>();

        // TodoContext
        builder.Services.AddDbContext<TodoContext>(options =>
        {
            options.UseMySql(todoDbConnectionString, todoServerVersion);
        });


        // Enregistrement du contrôleur et de la page pour le contact
        builder.Services.AddTransient<ContactsController>();
        builder.Services.AddTransient<ContactsPage>();
        
        // Enregistrement du contrôleur et de la page pour latodo
        builder.Services.AddTransient<TodoPage>();
        builder.Services.AddTransient<TodoController>();

        return builder.Build();
    }
}