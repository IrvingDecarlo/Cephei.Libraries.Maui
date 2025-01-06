using SkiaSharp.Extended.UI.Controls;

namespace Cephei.MAUI.Lottie;

/// <summary>
/// Info pages are pages that can display any type of message.
/// </summary>
public partial class InfoPage : ContentPage
{
  /// <summary>
  /// Creates a new info page.
  /// </summary>
  /// <param name="title">The page's title.</param>
  /// <param name="text">The page's text.</param>
  /// <param name="lottie">The page's lottie image to show.</param>
  /// <param name="lottierepeat">Number of times for the lottie file to repeat.</param>
  /// <param name="buttontext">The page's button text.</param>
  public InfoPage(string title, string text, SKLottieImageSource lottie, int lottierepeat = 1, string buttontext = "OK")
	{
		InitializeComponent();
    Title = title;
    View.TitleText = title;
    View.Text = text;
    View.LottieSource = lottie;
    View.LottieRepeat = lottierepeat;
    View.ButtonText = buttontext;
  }
  /// <summary>
  /// Creates a new info page.
  /// </summary>
  /// <param name="title">The page's title.</param>
  /// <param name="text">The page's text.</param>
  /// <param name="lottie">The page's lottie image to show.</param>
  /// <param name="lottierepeat">Number of times for the lottie file to repeat.</param>
  /// <param name="clicked">Action to take when the button is clicked.</param>
  /// <param name="buttontext">The page's button text.</param>
  public InfoPage(string title, string text, SKLottieImageSource lottie, EventHandler clicked, int lottierepeat = 1, string buttontext = "OK")
    : this(title, text, lottie, lottierepeat, buttontext)
    => View.OnClicked += clicked;
}