using mathGameUI.Data;

namespace mathGameUI;

public partial class App : Application
{
	public static GameRepository GameRepository { get; set; }		
	public App(GameRepository gameRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();
		GameRepository	= gameRepository;
	}
}
