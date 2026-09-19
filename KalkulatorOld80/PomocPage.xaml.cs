namespace KalkulatorOld80;

public partial class PomocPage : ContentPage
{
	public PomocPage()
	{
		InitializeComponent();
	}
    private async void btnWroc_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}