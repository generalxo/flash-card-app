using CommunityToolkit.Maui;
using flash_card_app.Helpers;
using flash_card_app.Models;
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
            });
        builder.UseMauiCommunityToolkit();
        string dbPath = FileAccessHelper.GetLocalFilePath("flashcard.db");
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<FlashCardModel>(s, dbPath));
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
