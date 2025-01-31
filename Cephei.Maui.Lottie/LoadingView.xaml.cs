using SkiaSharp.Extended.UI.Controls;

namespace Cephei.Maui.Lottie;

/// <summary>
/// The LoadingView component is used on pages to denote that content is being loaded.
/// </summary>
public partial class LoadingView : ContentView
{
  /// <summary>
  /// Creates a new LoadingView.
  /// </summary>
  public LoadingView()
  {
    InitializeComponent();
    BindingContext = this;
  }

  #region public

  // EVENTS

  /// <summary>
  /// OnLoadingStarted is called when loading begins. If no action is assigned to this event then it will show the LoadingView.
  /// </summary>
  public event Action<LoadingView>? OnLoadingStarted;

  /// <summary>
  /// OnLoadingFinished is called when loading ends. If no action is assigned to this event then it will hide the LoadingView.
  /// </summary>
  public event Action<LoadingView>? OnLoadingFinished;

  /// <summary>
  /// OnExcepion is raised when an exception is caught while performing the Loader action. It is performed in the main thread.
  /// </summary>
  public event Action<LoadingView, Exception>? OnException;

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
  public static readonly BindableProperty StyleTitleProperty = BindableProperty.Create(nameof(StyleTitle), typeof(Style), typeof(LoadingView));

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
  public static readonly BindableProperty StyleTextProperty = BindableProperty.Create(nameof(StyleText), typeof(Style), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the retry button's style.
  /// </summary>
  public Style StyleButton
  {
    set => SetValue(StyleButtonProperty, value);
    get => (Style)GetValue(StyleButtonProperty);
  }
  /// <summary>
  /// StyleButton bindable property.
  /// </summary>
  public static readonly BindableProperty StyleButtonProperty = BindableProperty.Create(nameof(StyleButton), typeof(Style), typeof(LoadingView));

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
  public static readonly BindableProperty LottieSourceProperty = BindableProperty.Create(nameof(LottieSource), typeof(SKLottieImageSource), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the image source for when the view is loading.
  /// </summary>
  public SKLottieImageSource? LoadingLottieSource
  {
    set => SetValue(LoadingLottieSourceProperty, value);
    get => GetValue(LoadingLottieSourceProperty) as SKLottieImageSource;
  }
  /// <summary>
  /// LoadingLottieSource bindable property.
  /// </summary>
  public static readonly BindableProperty LoadingLottieSourceProperty = BindableProperty.Create(nameof(LoadingLottieSource), typeof(SKLottieImageSource), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the image source for when an exception is thrown while loading.
  /// </summary>
  public SKLottieImageSource? ErrorLottieSource
  {
    set => SetValue(ErrorLottieSourceProperty, value);
    get => GetValue(ErrorLottieSourceProperty) as SKLottieImageSource;
  }
  /// <summary>
  /// ErrorLottieSource bindable property.
  /// </summary>
  public static readonly BindableProperty ErrorLottieSourceProperty = BindableProperty.Create(nameof(ErrorLottieSource), typeof(SKLottieImageSource), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the view's title.
  /// </summary>
  public string? Title
  {
    set => SetValue(TitleProperty, value);
    get => GetValue(TitleProperty) as string;
  }
  /// <summary>
  /// Title bindable property.
  /// </summary>
  public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the view's text.
  /// </summary>
  public string? Text
  {
    set => SetValue(TextProperty, value);
    get => GetValue(TextProperty) as string;
  }
  /// <summary>
  /// Text bindable property.
  /// </summary>
  public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the title for when the view is loading.
  /// </summary>
  public string? LoadingTitle
  {
    set => SetValue(LoadingTitleProperty, value);
    get => GetValue(LoadingTitleProperty) as string;
  }
  /// <summary>
  /// LoadingTitle bindable property.
  /// </summary>
  public static readonly BindableProperty LoadingTitleProperty = BindableProperty.Create(nameof(LoadingTitle), typeof(string), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the text for when the view is loading.
  /// </summary>
  public string? LoadingText
  {
    set => SetValue(LoadingTextProperty, value);
    get => GetValue(LoadingTextProperty) as string;
  }
  /// <summary>
  /// LoadingText bindable property.
  /// </summary>
  public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(nameof(LoadingText), typeof(string), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the title for when the view throws an exception.
  /// </summary>
  public string? ErrorTitle
  {
    set => SetValue(ErrorTitleProperty, value);
    get => GetValue(ErrorTitleProperty) as string;
  }
  /// <summary>
  /// ErrorTitle bindable property.
  /// </summary>
  public static readonly BindableProperty ErrorTitleProperty = BindableProperty.Create(nameof(ErrorTitle), typeof(string), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the text for when the view throws an exception. Can use string.Format with the following indexes:
  /// 0: The exception type;
  /// 1: The exception message.
  /// </summary>
  public string? ErrorText
  {
    set => SetValue(ErrorTextProperty, value);
    get => GetValue(ErrorTextProperty) as string;
  }
  /// <summary>
  /// ErrorText bindable property.
  /// </summary>
  public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(LoadingView));

  /// <summary>
  /// Gets or sets the retry button's text.
  /// </summary>
  public string? ButtonText
  {
    set => SetValue(ButtonTextProperty, value);
    get => GetValue(ButtonTextProperty) as string;
  }
  /// <summary>
  /// ButtonText bindable property.
  /// </summary>
  public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(LoadingView));

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
  public static readonly BindableProperty LottieRepeatProperty = BindableProperty.Create(nameof(LottieRepeat), typeof(int), typeof(LoadingView));

  /// <summary>
  /// Number of times that the loading lottie has to repeat.
  /// </summary>
  public int LoadingLottieRepeat
  {
    set => SetValue(LoadingLottieRepeatProperty, value);
    get => (int)GetValue(LoadingLottieRepeatProperty);
  }
  /// <summary>
  /// LoadingLottieRepeat bindable property.
  /// </summary>
  public static readonly BindableProperty LoadingLottieRepeatProperty = BindableProperty.Create(nameof(LoadingLottieRepeat), typeof(int), typeof(LoadingView));

  /// <summary>
  /// Number of times that the error lottie has to repeat.
  /// </summary>
  public int ErrorLottieRepeat
  {
    set => SetValue(ErrorLottieRepeatProperty, value);
    get => (int)GetValue(ErrorLottieRepeatProperty);
  }
  /// <summary>
  /// ErrorLottieRepeat bindable property.
  /// </summary>
  public static readonly BindableProperty ErrorLottieRepeatProperty = BindableProperty.Create(nameof(ErrorLottieRepeat), typeof(int), typeof(LoadingView));

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
  public static readonly BindableProperty LottieWidthProperty = BindableProperty.Create(nameof(LottieWidth), typeof(int), typeof(LoadingView));

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
  public static readonly BindableProperty LottieHeightProperty = BindableProperty.Create(nameof(LottieHeight), typeof(int), typeof(LoadingView));

  // METHODS

  /// <summary>
  /// Performs the LoadingView's Load procedure.
  /// </summary>
  public async void Load(Func<LoadingView, Task> loader)
  {
    load_last = loader;
    Reset();
    LoadStart();
    try { await loader(this); }
    catch (Exception e)
    {
      MainThread.BeginInvokeOnMainThread(() =>
      {
        LottieSource = ErrorLottieSource;
        LottieRepeat = ErrorLottieRepeat;
        Title = ErrorTitle;
        Text = ErrorText is null ? "" : string.Format(ErrorText, e.GetType(), e.Message);
        ButtonRetry.IsVisible = true;
        OnException?.Invoke(this, e);
      });
      return;
    }
    LoadFinish();
  }

  #endregion

  #region private

  // VARIABLES

  private Func<LoadingView, Task>? load_last = null;

  // METHODS

  private void Reset(Action<LoadingView>? on_reset = null)
  {
    MainThread.BeginInvokeOnMainThread(() =>
    {
      LottieSource = LoadingLottieSource;
      LottieRepeat = LoadingLottieRepeat;
      Title = LoadingTitle;
      Text = LoadingText;
      ButtonRetry.IsVisible = false;
      on_reset?.Invoke(this);
    });
  }

  private void LoadStart()
  {
    if (OnLoadingStarted is null)
    {
      IsVisible = true;
      return;
    }
    OnLoadingStarted(this);
  }

  private void LoadFinish()
  {
    if (OnLoadingFinished is null)
    {
      IsVisible = false;
      return;
    }
    OnLoadingFinished(this);
  }

  private void Button_Clicked(object sender, EventArgs e)
  {
    if (load_last is null) return;
    Load(load_last);
  }

  #endregion
}