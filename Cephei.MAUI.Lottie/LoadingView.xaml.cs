using SkiaSharp.Extended.UI.Controls;

namespace Cephei.MAUI.Lottie;

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
    set => LabelTitle.Style = value;
    get => LabelTitle.Style;
  }

  /// <summary>
  /// Gets or sets the text's style.
  /// </summary>
  public Style StyleText
  {
    set => LabelDetail.Style = value;
    get => LabelDetail.Style;
  }

  /// <summary>
  /// Gets or sets the retry button's style.
  /// </summary>
  public Style StyleButton
  {
    set => ButtonRetry.Style = value;
    get => ButtonRetry.Style;
  }

  /// <summary>
  /// Gets or sets the image source for when the view is loading.
  /// </summary>
  public SKLottieImageSource? LoadingLottieSource { get; set; }

  /// <summary>
  /// Gets or sets the image source for when an exception is thrown while loading.
  /// </summary>
  public SKLottieImageSource? ErrorLottieSource { get; set; }

  /// <summary>
  /// Gets or sets the title for when the view is loading.
  /// </summary>
  public string? LoadingTitle { get; set; }

  /// <summary>
  /// Gets or sets the text for when the view is loading.
  /// </summary>
  public string? LoadingText { get; set; }

  /// <summary>
  /// Gets or sets the title for when the view throws an exception.
  /// </summary>
  public string? ErrorTitle { get; set; }

  /// <summary>
  /// Gets or sets the text for when the view throws an exception. Can use string.Format with the following indexes:
  /// 0: The exception type;
  /// 1: The exception message.
  /// </summary>
  public string? ErrorText { get; set; }

  /// <summary>
  /// Number of times that the loading lottie has to repeat. Is -1 by default to signal an infinite loop.
  /// </summary>
  public int LoadingLottieRepeat { get; set; } = -1;

  /// <summary>
  /// Number of times that the error lottie has to repeat. Is 0 by default to fire only once.
  /// </summary>
  public int ErrorLottieRepeat { get; set; } = 0;

  /// <summary>
  /// Gets or sets the retry button's text.
  /// </summary>
  public string? ButtonText
  {
    set => ButtonRetry.Text = value;
    get => ButtonRetry.Text;
  }

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
        LottieView.Source = ErrorLottieSource;
        LottieView.RepeatCount = ErrorLottieRepeat;
        LabelTitle.Text = ErrorTitle;
        LabelDetail.Text = ErrorText is null ? "" : string.Format(ErrorText, e.GetType(), e.Message);
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
      LottieView.Source = LoadingLottieSource;
      LottieView.RepeatCount = LoadingLottieRepeat;
      LabelTitle.Text = LoadingTitle;
      LabelDetail.Text = LoadingText;
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