namespace MathGame.Maui
{
    public partial class PreviousGames : ContentPage
    {
        public PreviousGames()
        {
            InitializeComponent();
            RefreshGameList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshGameList();
        }

        private void RefreshGameList()
        {
            gamesList.ItemsSource = App.GameRepository.GetAllGames();
        }

        public async void OnEdit(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new editPage((int)button.BindingContext));
        }

        private void OnDelete(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            App.GameRepository.Delete((int)button.BindingContext);
            RefreshGameList();
        }
    }
}
