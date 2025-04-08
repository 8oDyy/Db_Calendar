using Microsoft.EntityFrameworkCore;
using BOULICAUT_RAFFORT_Calendar.Controllers;
using BOULICAUT_RAFFORT_Calendar.Views;
using BOULICAUT_RAFFORT_Calendar.Services;
using BOULICAUT_RAFFORT_Calendar;
using BOULICAUT_RAFFORT_Calendar.Models; // Pour ContactsContext

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

        // ✅ Connexion EF Core pour la base CONTACTS
        var contactDbConnectionString = Preferences.Get("ContactDbConnectionString", "server=172.20.10.12;port=3306;database=contact-db;user=root;password=HBca06022004!;");
        var contactServerVersion = new MySqlServerVersion(new Version(8, 0, 36));

        builder.Services.AddDbContext<ContactsContext>(options =>
        {
            options.UseMySql(contactDbConnectionString, contactServerVersion);
        });

        // ✅ Connexion EF Core pour la base TODO
        var todoDbConnectionString = Preferences.Get("TodoDbConnectionString", "server=172.20.10.12;port=3306;database=todo-db;user=root;password=HBca06022004!;");
        var todoServerVersion = new MySqlServerVersion(new Version(8, 0, 36));

        builder.Services.AddDbContext<TodoContext>(options =>
        {
            options.UseMySql(todoDbConnectionString, todoServerVersion);
        });

        // ✅ Enregistrement des contrôleurs et pages
        builder.Services.AddTransient<ContactsController>();
        builder.Services.AddTransient<ContactsPage>();

        builder.Services.AddTransient<TodoController>();
        builder.Services.AddTransient<TodoPage>();
        
        builder.Services.AddTransient<CalendarPage>();




        return builder.Build();
    }
}