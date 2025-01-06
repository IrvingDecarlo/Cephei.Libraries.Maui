using Cephei.MAUI.Testing.LottieTest;
using Cephei.MAUI.Lottie;
using SkiaSharp.Extended.UI.Controls;

namespace Cephei.MAUI.Testing;

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