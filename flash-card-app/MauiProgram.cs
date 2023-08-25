using CommunityToolkit.Maui;
using flash_card_app.Helpers;
using flash_card_app.Services;
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
		string dbPath = FileAccessHelper.GetLocalFilePath("appDb.db3");
		builder.Services.AddSingleton<DbContext>(s => ActivatorUtilities.CreateInstance<DbContext>(s, dbPath));
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
