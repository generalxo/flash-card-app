﻿using CommunityToolkit.Maui;
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
			});

		builder.UseMauiCommunityToolkit();

		//DataBase
		string dbPath = FileAccessHelper.GetLocalFilePath("appDb.db3");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<DbContext>(s, dbPath));

		//ViewModels
		builder.Services.AddSingleton<CollectionViewModel>();

		//Views
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<CollectionPage>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
