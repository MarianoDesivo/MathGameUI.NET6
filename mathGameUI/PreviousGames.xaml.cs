namespace mathGameUI;

public partial class PreviousGames : ContentPage
{
	public PreviousGames()
	{
		InitializeComponent();
		gamesList.ItemsSource = App.GameRepository.GetAllGames();

    }

	public void OnDelete(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		App.GameRepository.Delete((int)button.BindingContext);

		gamesList.ItemsSource = App.GameRepository.GetAllGames();
	}
}