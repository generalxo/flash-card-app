using CommunityToolkit.Maui;
using flash_card_app.Helpers;
using flash_card_app.Services;
using flash_card_app.ViewModels;
using flash_card_app.Views;
using Microsoft.Extensions.Logging;

namespace flash_card_app;

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
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons-Regular");
                fonts.AddFont("RobotoMono-Regular.ttf", "RobotoMono-Regular");
                fonts.AddFont("RobotoMono-SemiBold.ttf", "RobotoMono-SemiBold");
            });

        builder.UseMauiCommunityToolkit();

        //DataBase
        string dbPath = FileAccessHelper.GetLocalFilePath("appDb.db3");
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<DbContext>(s, dbPath));

        //ViewModels
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<DeckViewModel>();
        builder.Services.AddTransient<CreateDeckViewModel>();
        builder.Services.AddTransient<CardsViewModel>();
        builder.Services.AddTransient<CreateCardViewModel>();
        builder.Services.AddTransient<EditCardViewModel>();
        builder.Services.AddTransient<SelectDeckViewModel>();
        builder.Services.AddTransient<PlayPageViewModel>();

        //Views
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<DeckPage>();
        builder.Services.AddTransient<CreateDeckPage>();
        builder.Services.AddTransient<CardsPage>();
        builder.Services.AddTransient<CreateCardPage>();
        builder.Services.AddTransient<EditCardPage>();
        builder.Services.AddTransient<SelectDeckPage>();
        builder.Services.AddTransient<PlayPage>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
