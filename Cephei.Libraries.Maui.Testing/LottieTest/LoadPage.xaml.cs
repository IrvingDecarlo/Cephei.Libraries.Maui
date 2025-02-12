using SkiaSharp.Extended.UI.Controls;

namespace Cephei.Libraries.Maui.Testing.LottieTest;

public partial class LoadPage : ContentPage
{
	public LoadPage()
	{
		InitializeComponent();
    LoadingView.Load(async (x) =>
		{
			await Task.Delay(2000);
			throw new Exception("Test");
		});
  }

  private void LoadingView_OnLoadingFinished(Lottie.LoadingView obj)
  {
		obj.LottieSource = new SKFileLottieImageSource() { File = "Lottie/checkmark.json" };
		obj.Title = "Loading Complete";
		obj.Text = "lol";
  }
}