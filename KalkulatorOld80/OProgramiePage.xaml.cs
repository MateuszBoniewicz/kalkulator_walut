namespace KalkulatorOld80;

public partial class OProgramiePage : ContentPage
{
	public OProgramiePage()
	{
		InitializeComponent();
	}
	private async void btnWroc_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
    }
}