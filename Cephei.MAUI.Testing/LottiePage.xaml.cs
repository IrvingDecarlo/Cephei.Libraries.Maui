using Cephei.MAUI.Testing.LottieTest;

namespace Cephei.MAUI.Testing;

public partial class LottiePage : ContentPage
{
	public LottiePage()
	{
		InitializeComponent();
	}

	private void ButtonLoad_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new LoadPage());
}