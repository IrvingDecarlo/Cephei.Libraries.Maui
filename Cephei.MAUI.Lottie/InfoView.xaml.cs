using SkiaSharp.Extended.UI.Controls;

namespace Cephei.Maui.Lottie;

/// <summary>
/// Info views can display any type of message with a lottie animation and a button included.
/// </summary>
public partial class InfoView : ContentView
{
  /// <summary>
  /// Creates a new info page.
  /// </summary>
  public InfoView()
	{
		InitializeComponent();
    BindingContext = this;
  }

  #region public

  // EVENTS

  /// <summary>
  /// Action to take when the button is clicked. Null makes it pop the page.
  /// </summary>
  public event EventHandler? OnClicked;

  // PROPERTIES

  /// <summary>
  /// Gets or sets the title's style.
  /// </summary>
  public Style StyleTitle
  {
    set => SetValue(StyleTitleProperty, value);
    get => (Style)GetValue(StyleTitleProperty);
  }
  /// <summary>
  /// StyleTitle bindable property.
  /// </summary>
  public static readonly BindableProperty StyleTitleProperty = BindableProperty.Create(nameof(StyleTitle), typeof(Style), typeof(InfoView));

  /// <summary>
  /// Gets or sets the text's style.
  /// </summary>
  public Style StyleText
  {
    set => SetValue(StyleTextProperty, value);
    get => (Style)GetValue(StyleTextProperty);
  }
  /// <summary>
  /// StyleText bindable property.
  /// </summary>
  public static readonly BindableProperty StyleTextProperty = BindableProperty.Create(nameof(StyleText), typeof(Style), typeof(InfoView));

  /// <summary>
  /// Gets or sets the button's style.
  /// </summary>
  public Style StyleButton
  {
    set => SetValue(StyleButtonProperty, value);
    get => (Style)GetValue(StyleButtonProperty);
  }
  /// <summary>
  /// StyleText bindable property.
  /// </summary>
  public static readonly BindableProperty StyleButtonProperty = BindableProperty.Create(nameof(StyleButton), typeof(Style), typeof(InfoView));

  /// <summary>
  /// Gets or sets the current lottie source.
  /// </summary>
  public SKLottieImageSource? LottieSource
  {
    set => SetValue(LottieSourceProperty, value);
    get => GetValue(LottieSourceProperty) as SKLottieImageSource;
  }
  /// <summary>
  /// LottieSource bindable property.
  /// </summary>
  public static readonly BindableProperty LottieSourceProperty = BindableProperty.Create(nameof(LottieSource), typeof(SKLottieImageSource), typeof(InfoView));

  /// <summary>
  /// Gets or sets the title's text.
  /// </summary>
  public string TitleText
  {
    set => SetValue(TitleTextProperty, value);
    get => (string)GetValue(TitleTextProperty);
  }
  /// <summary>
  /// TitleText bindable property.
  /// </summary>
  public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(InfoView));

  /// <summary>
  /// Gets or sets the button's text.
  /// </summary>
  public string ButtonText
  {
    set => SetValue(ButtonTextProperty, value);
    get => (string)GetValue(ButtonTextProperty);
  }
  /// <summary>
  /// TitleText bindable property.
  /// </summary>
  public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(InfoView));

  /// <summary>
  /// Gets or sets the view's text.
  /// </summary>
  public string Text
  {
    set => SetValue(TextProperty, value);
    get => (string)GetValue(TextProperty);
  }
  /// <summary>
  /// Text bindable property.
  /// </summary>
  public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(InfoView));

  /// <summary>
  /// Gets or sets the lottie's repeat count.
  /// </summary>
  public int LottieRepeat
  {
    set => SetValue(LottieRepeatProperty, value);
    get => (int)GetValue(LottieRepeatProperty);
  }
  /// <summary>
  /// LottieRepeat bindable property.
  /// </summary>
  public static readonly BindableProperty LottieRepeatProperty = BindableProperty.Create(nameof(LottieRepeat), typeof(int), typeof(InfoView));

  /// <summary>
  /// Determines the lottie view's width.
  /// </summary>
  public int LottieWidth
  {
    set => SetValue(LottieWidthProperty, value);
    get => (int)GetValue(LottieWidthProperty);
  }
  /// <summary>
  /// LottieWidth bindable property.
  /// </summary>
  public static readonly BindableProperty LottieWidthProperty = BindableProperty.Create(nameof(LottieWidth), typeof(int), typeof(InfoView));

  /// <summary>
  /// Determines the lottie view's height.
  /// </summary>
  public int LottieHeight
  {
    set => SetValue(LottieHeightProperty, value);
    get => (int)GetValue(LottieHeightProperty);
  }
  /// <summary>
  /// LottieHeight bindable property.
  /// </summary>
  public static readonly BindableProperty LottieHeightProperty = BindableProperty.Create(nameof(LottieHeight), typeof(int), typeof(InfoView));

  #endregion

  #region private

  private async void ButtonConfirm_Clicked(object sender, EventArgs e)
  {
    if (OnClicked is null) await Navigation.PopAsync();
    else OnClicked(sender, e);
  }

  #endregion
}