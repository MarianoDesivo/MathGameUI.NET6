using mathGameUI.Data;
using mathGameUI.Models;
using Windows.Gaming.XboxLive.Storage;

namespace mathGameUI;

public partial class GamePage : ContentPage
{
	public string GameType { get; set; }
    int n1;
    int n2;
    int score = 0;
	const int totalQuestions = 2;
	int gamesLeft = totalQuestions;
	public GamePage(string gameType)
	{
		InitializeComponent();
		GameType = gameType;
		BindingContext = this;
		CreateNewQuestion();

    }
	private void CreateNewQuestion()
	{

		var gameOperand = GameType switch
		{
			"Suma" => "+",
			"Resta" => "-",
			"Multiplicaci�n" => "*",
			"Divisi�n" => "/",
			_ => ""
				
		};
		var random = new Random();	
		if(GameType == "Divisi�n")
		{
			do
			{
				n1 = random.Next(1, 100);
				n2 = random.Next(1, 100);
			} while (n1 % n2 != 0);
        }	
		else
		{
            n1 = random.Next(1, 10);
            n2 = random.Next(1, 10);
        }

		QuestionLabel.Text = $"{n1} {gameOperand} {n2}";
	}

	private void OnAnswerSubmitted(object sender, EventArgs e) {
		int answer = Int32.Parse(AnswerEntry.Text);
		bool isCorrect = false;

		switch (GameType)
		{
			case "Suma":
				isCorrect = answer == n1+n2;
				break;
            case "Resta":
                isCorrect = answer == n1 - n2;
                break;
            case "Multiplicaci�n":
                isCorrect = answer == n1 * n2;
                break;
            case "Divisi�n":
                isCorrect = answer == n1 / n2;
                break;
        }
		gamesLeft--;
		AnswerEntry.Text = "";
		ProcessAnswer(isCorrect);
    }

	private void GameOver()
	{
		QuestionArea.IsVisible = false;
		GameOverLabel.Text = $"Fin del juego\n Puntuaci�n: {score} \n Cantidad de preguntas : {totalQuestions}";

		GameOperand gameOperand = GameType switch
		{
			"Suma" => GameOperand.suma,
			"Resta" => GameOperand.resta,
			"Multiplicaci�n" => GameOperand.multiplicacion,
			"Divisi�n" => GameOperand.division
		};

		App.GameRepository.AddGame(new Game()
		{
			Type = gameOperand,
			DatePlayed = DateTime.Now.Date,
			Score = score
			


		});
	}

	private void ProcessAnswer(bool isCorrect)
	{
		if (isCorrect)
		{
			score++;
			AnswerLabel.Text = "Correcto!!";
		}
		else
		{
            AnswerLabel.Text = "Incorrecto";
        }
		if (gamesLeft > 0)
		{
			CreateNewQuestion();
		}
		else
		{
			GameOver();
		}

    }
}