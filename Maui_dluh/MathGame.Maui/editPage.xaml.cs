using MathsGame.Models;


namespace MathGame.Maui;

public partial class editPage : ContentPage
{
	public int ID;
    public int Castka;
    public string UserName;
    public string vstup;

	public editPage(int EntryID)
	{
		InitializeComponent();
		ID = EntryID;

        List<Game> newlist = App.GameRepository.GetOneGame(ID);
        UserName = newlist[0].Name;
        Castka = newlist[0].Score;


        Title = $"Upravuješ dlužníka: {UserName}";

        cilso.Text = newlist[0].Score.ToString();
    }




    private async void Button_Clicked(object sender, EventArgs e)
    {
        int score;
        if (int.TryParse(vstup, out score))
        {
            App.GameRepository.Edit(new Game
            {
                Id = ID,
                DatePlayed = DateTime.Now,
                Name = UserName,
                Score = score
            });
        }
        else
        {
            App.GameRepository.Edit(new Game
            {
                Id = ID,
                DatePlayed = DateTime.Now,
                Name = UserName,
                Score = Castka
            });
        }

        await Navigation.PopAsync();
    }


    private void cilso_TextChanged(object sender, TextChangedEventArgs e)
    {
        vstup = cilso.Text;
    }
}