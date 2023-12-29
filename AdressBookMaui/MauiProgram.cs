using AdressBook_Library.Services;
using AdressBookMaui.Pages;
using AdressBookMaui.ViewModels;
using Microsoft.Extensions.Logging;
using AdressBook_Library.Interfaces;


namespace AdressBookMaui
{
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

            builder.Services.AddSingleton<IPersonService, PersonService>();
            builder.Services.AddSingleton<IFileService, FileService>();

            builder.Services.AddSingleton<PersonDetailsPage>();
            builder.Services.AddSingleton<PersonDetailsViewModel>();

            builder.Services.AddSingleton<AddPersonPage>();
            builder.Services.AddSingleton<AddPersonViewModel>();

            builder.Services.AddSingleton<AllPersonsPage>();
            builder.Services.AddSingleton<AllPersonsViewModel>();

            builder.Logging.AddDebug();

            return builder.Build();
        }
    }
}
