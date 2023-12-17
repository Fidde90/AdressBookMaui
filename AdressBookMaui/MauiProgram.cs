using AdressBookMaui.Pages;
using AdressBookMaui.ViewModels;
using Microsoft.Extensions.Logging;

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

            builder.Services.AddSingleton<AddPersonPage>();
            builder.Services.AddSingleton<AddPersonViewModel>();
          

            builder.Logging.AddDebug();


            return builder.Build();
        }
    }
}
