using Cephei.Libraries.Maui.Testing.LottieTest;
using Cephei.Libraries.Maui.Lottie;
using SkiaSharp.Extended.UI.Controls;

namespace Cephei.Libraries.Maui.Testing;

public partial class LottiePage : ContentPage
{
	public LottiePage()
	{
		InitializeComponent();
	}

	private void ButtonLoad_Clicked(object sender, EventArgs e) => Navigation.PushAsync(new LoadPage());

	private void ButtonInfo_Clicked(object sender, EventArgs e) => Navigation.PushAsync(
		new InfoPage("Test Page", "Page Text", new SKFileLottieImageSource() { File = "Lottie/loading.json" }));
}