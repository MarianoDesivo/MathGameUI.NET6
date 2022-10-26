using mathGameUI.Data;

namespace mathGameUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Orbitron-Bold.ttf", "OrbitronBold");
            });

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "game.db");

		builder.Services.AddSingleton(s =>
			ActivatorUtilities.CreateInstance<GameRepository>(s, dbPath));

		return builder.Build();
	}
}
