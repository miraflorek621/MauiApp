using MathsGame.Models;

namespace MathGame.Maui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        App.GameRepository.CreateTable();
    }

    private async void pridat(object sender, EventArgs e)
    {
        if (vstup.Text == null || vstup.Text.Length < 0 ||  vstup.Text.Length > 20) 
        {
            Debug.Text = "Zadej jiné jméno (Méně než 20 znaků a více než 0)";
            return;
        }

        Debug.Text = "";

        try
        {
            App.GameRepository.Add(new Game
            {
                DatePlayed = DateTime.Now,
                Name = vstup.Text,
                Score = Int32.Parse(vstupScore.Text)
            });
            await Navigation.PushAsync(new PreviousGames());
        }
        catch {}

        
    }

    private async void OnViewPreviousGamesChosen(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PreviousGames());
    }
}

