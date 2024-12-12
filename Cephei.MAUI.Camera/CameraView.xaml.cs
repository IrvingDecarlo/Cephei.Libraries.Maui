using Camera.MAUI.ZXingHelper;
using Camera.MAUI;

namespace Cephei.MAUI.Camera;

/// <summary>
/// The CameraView is a standardized camera view with scanning overlay.
/// </summary>
public partial class CameraView : ContentView, IDrawable
{
  /// <summary>
  /// Creates a new overlayed CameraView.
  /// </summary>
  public CameraView()
  {
    InitializeComponent();
    BindingContext = this;
    CameraViw.BarcodeDetected += CameraViw_BarcodeDetected;
    GraphicsOverlay.Drawable = this;
  }

  #region overrides

  void IDrawable.Draw(ICanvas canvas, RectF rect)
  {
    if (OverlayWidth < 1 || OverlayHeight < 1) return;
    RectF overrect = new(rect.Left + ((rect.Width - OverlayWidth) * 0.5f), rect.Top + ((rect.Height - OverlayHeight) * 0.5f), OverlayWidth, OverlayHeight);
    canvas.FillColor = OverlayColor;
    canvas.SubtractFromClip(overrect);
    canvas.FillRectangle(rect.Left, rect.Top, rect.Width, rect.Height);
    canvas.StrokeColor = OverlayCornerColor;
    canvas.StrokeSize = OverlayCornerThickness;
    canvas.StrokeLineCap = LineCap.Square;
    DrawCorner(canvas, overrect.Left, overrect.Top, OverlayCornerWidth, OverlayCornerHeight);
    DrawCorner(canvas, overrect.Left, overrect.Bottom, OverlayCornerWidth, -OverlayCornerHeight);
    DrawCorner(canvas, overrect.Right, overrect.Top, -OverlayCornerWidth, OverlayCornerHeight);
    DrawCorner(canvas, overrect.Right, overrect.Bottom, -OverlayCornerWidth, -OverlayCornerHeight);
  }

  #endregion

  #region public

  // EVENTS

  /// <summary>
  /// The OnCameraNotFound event is raised when the system fails to detect a camera that matches the specified criteria.
  /// By default, it throws an exception if not consumed.
  /// </summary>
  public event EventHandler<CameraType>? OnCameraNotFound;

  /// <summary>
  /// OnBarcodeDetected is raised when the camera detects a barcode.
  /// </summary>
  public event EventHandler<string>? OnBarcodeDetected;

  // PROPERTIES

  /// <summary>
  /// Gets the camera that is performing the scanning.
  /// </summary>
  public CameraInfo Camera => CameraViw.Camera;

  /// <summary>
  /// Gets or sets the overlay color. Default is transparent black.
  /// </summary>
  public Color OverlayColor
  {
    set => SetValue(OverlayColorProperty, value);
    get => (Color)GetValue(OverlayColorProperty);
  }
  /// <summary>
  /// The OverlayColor property.
  /// </summary>
  public static readonly BindableProperty OverlayColorProperty 
    = BindableProperty.Create(nameof(OverlayColor), typeof(Color), typeof(CameraView), new Color(0, 0, 0, 120), propertyChanged:OnGraphicsOverlayChange);

  /// <summary>
  /// Gets or sets the overlay corner color. Default is white.
  /// </summary>
  public Color OverlayCornerColor
  {
    set => SetValue(OverlayCornerColorProperty, value);
    get => (Color)GetValue(OverlayCornerColorProperty);
  }
  /// <summary>
  /// The OverlayCornerColor property.
  /// </summary>
  public static readonly BindableProperty OverlayCornerColorProperty 
    = BindableProperty.Create(nameof(OverlayCornerColor), typeof(Color), typeof(CameraView), new Color(1f), propertyChanged:OnGraphicsOverlayChange);

  /// <summary>
  /// Specifies the camera type that will be used by this CameraView (if it is a front or back camera).
  /// </summary>
  public CameraType CameraType
  {
    set => SetValue(CameraTypeProperty, value);
    get => (CameraType)GetValue(CameraTypeProperty);
  }
  /// <summary>
  /// The CameraType property.
  /// </summary>
  public static readonly BindableProperty CameraTypeProperty = BindableProperty.Create(nameof(CameraType), typeof(CameraType), typeof(CameraView), CameraType.Any);

  /// <summary>
  /// Gets or sets the camera's width.
  /// </summary>
  /// <remarks>Must be set or the application will silently crash.</remarks>
  public double CameraWidth
  {
    set => SetValue(CameraWidthProperty, value);
    get => (double)GetValue(CameraWidthProperty);
  }
  /// <summary>
  /// The CameraWidth property.
  /// </summary>
  public static readonly BindableProperty CameraWidthProperty 
    = BindableProperty.Create(nameof(CameraWidth), typeof(double), typeof(CameraView), propertyChanged:OnGraphicsOverlayChange);

  /// <summary>
  /// Gets or sets the camera's height.
  /// </summary>
  /// <remarks>Must be set or the application will silently crash.</remarks>
  public double CameraHeight
  {
    set => SetValue(CameraHeightProperty, value);
    get => (double)GetValue(CameraHeightProperty);
  }
  /// <summary>
  /// The CameraHeight property.
  /// </summary>
  public static readonly BindableProperty CameraHeightProperty 
    = BindableProperty.Create(nameof(CameraHeight), typeof(double), typeof(CameraView), propertyChanged:OnGraphicsOverlayChange);

  /// <summary>
  /// Gets or sets the overlay's uncovered width. Setting it to 0 or less will disable the overlay.
  /// </summary>
  public float OverlayWidth
  {
    set => SetValue(OverlayWidthProperty, value);
    get => (float)GetValue(OverlayWidthProperty);
  }
  /// <summary>
  /// The OverlayWidth property.
  /// </summary>
  public static readonly BindableProperty OverlayWidthProperty 
    = BindableProperty.Create(nameof(OverlayWidth), typeof(float), typeof(CameraView), propertyChanged:OnGraphicsOverlayChange);

  /// <summary>
  /// Gets or sets the overlay's uncovered height. Setting it to 0 or less will disable the overlay.
  /// </summary>
  public float OverlayHeight
  {
    set => SetValue(OverlayHeightProperty, value);
    get => (float)GetValue(OverlayHeightProperty);
  }
  /// <summary>
  /// The OverlayHeight property.
  /// </summary>
  public static readonly BindableProperty OverlayHeightProperty 
    = BindableProperty.Create(nameof(OverlayHeight), typeof(float), typeof(CameraView), propertyChanged:OnGraphicsOverlayChange);

  /// <summary>
  /// Gets or sets the overlay's corner width.
  /// </summary>
  public float OverlayCornerWidth
  {
    set => SetValue(OverlayCornerWidthProperty, value);
    get => (float)GetValue(OverlayCornerWidthProperty);
  }
  /// <summary>
  /// The OverlayCornerWidth property.
  /// </summary>
  public static readonly BindableProperty OverlayCornerWidthProperty 
    = BindableProperty.Create(nameof(OverlayCornerWidth), typeof(float), typeof(CameraView), propertyChanged: OnGraphicsOverlayChange);

  /// <summary>
  /// Gets or sets the overlay's corner height. Default is 16.
  /// </summary>
  public float OverlayCornerHeight
  {
    set => SetValue(OverlayCornerHeightProperty, value);
    get => (float)GetValue(OverlayCornerHeightProperty);
  }
  /// <summary>
  /// The OverlayCornerHeight property.
  /// </summary>
  public static readonly BindableProperty OverlayCornerHeightProperty 
    = BindableProperty.Create(nameof(OverlayCornerHeight), typeof(float), typeof(CameraView), propertyChanged: OnGraphicsOverlayChange);

  /// <summary>
  /// Gets or sets the overlay's corner thickness. Default is 4.
  /// </summary>
  public float OverlayCornerThickness
  {
    set => SetValue(OverlayCornerThicknessProperty, value);
    get => (float)GetValue(OverlayCornerThicknessProperty);
  }
  /// <summary>
  /// The OverlayCornerThickness property.
  /// </summary>
  public static readonly BindableProperty OverlayCornerThicknessProperty 
    = BindableProperty.Create(nameof(OverlayCornerThickness), typeof(float), typeof(CameraView), propertyChanged: OnGraphicsOverlayChange);

  /// <summary>
  /// Determines the camera's detection cooldown (in miliseconds).
  /// </summary>
  public int DetectionCooldown
  {
    set => SetValue(DetectionCooldownProperty, value);
    get => (int)GetValue(DetectionCooldownProperty);
  }
  /// <summary>
  /// The DetectionCooldown property.
  /// </summary>
  public static readonly BindableProperty DetectionCooldownProperty = BindableProperty.Create(nameof(DetectionCooldown), typeof(int), typeof(CameraView), 5000);

  /// <summary>
  /// Should the camera automatically start when the device's cameras are loaded?
  /// </summary>
  public bool AutoStart
  {
    set => SetValue(AutoStartProperty, value);
    get => (bool)GetValue(AutoStartProperty);
  }
  /// <summary>
  /// The AutoStart property.
  /// </summary>
  public static readonly BindableProperty AutoStartProperty = BindableProperty.Create(nameof(AutoStart), typeof(bool), typeof(CameraView), true);

  /// <summary>
  /// Keep the screen on while the camera is active?
  /// </summary>
  public bool KeepScreenOn
  {
    set => SetValue(KeepScreenOnProperty, value);
    get => (bool)GetValue(KeepScreenOnProperty);
  }
  /// <summary>
  /// The KeepScreenOn property.
  /// </summary>
  public static readonly BindableProperty KeepScreenOnProperty = BindableProperty.Create(nameof(KeepScreenOn), typeof(bool), typeof(CameraView));

  /// <summary>
  /// Enables or disables the camera's barcode scanning.
  /// </summary>
  public bool BarcodeScanning
  {
    set
    {
      SetValue(BarcodeScanningProperty, value);
      CameraViw.BarCodeDetectionEnabled = value;
    }
    get => (bool)GetValue(BarcodeScanningProperty);
  }
  /// <summary>
  /// The BarcodeScanning property.
  /// </summary>
  public static readonly BindableProperty BarcodeScanningProperty = BindableProperty.Create(nameof(BarcodeScanning), typeof(bool), typeof(CameraView));

  // METHODS

  /// <summary>
  /// Starts the camera. Does nothing if the Camera property is null.
  /// </summary>
  /// <exception cref="CameraOperationException"></exception>
  public async Task StartAsync()
  {
    if (CameraViw.Camera is null) return;
    HandleCameraResult(await CameraViw.StartCameraAsync());
    if (KeepScreenOn) DeviceDisplay.Current.KeepScreenOn = true;
    string prev = previous;
    await Task.Delay(DetectionCooldown);
    if (prev.Equals(previous)) previous = "";
  }

  /// <summary>
  /// Stops the camera.
  /// </summary>
  /// <exception cref="CameraOperationException"></exception>
  public async Task StopAsync()
  {
    if (CameraViw.Camera is null) return;
    HandleCameraResult(await CameraViw.StopCameraAsync());
    if (KeepScreenOn) DeviceDisplay.Current.KeepScreenOn = false;
  }

  #endregion

  #region private

  // FIELDS

  private string previous = "";

  // METHODS

  private void InvokeCameraNotFound(CameraType type)
  {
    if (OnCameraNotFound is null) throw new CameraNotFoundException(this, type);
    OnCameraNotFound(this, type);
  }

  private void HandleCameraResult(CameraResult result)
  {
    if (result == CameraResult.Success) return;
    throw new CameraOperationException(this, result);
  }

  private async void CameraViw_CamerasLoaded(object sender, EventArgs e)
  {
    if (CameraViw.NumCamerasDetected < 1)
    {
      InvokeCameraNotFound(CameraType);
      return;
    }
    if (CameraType == CameraType.Any) CameraViw.Camera = CameraViw.Cameras.FirstOrDefault();
    else
    {
      CameraPosition pos = CameraType switch
      {
        CameraType.Front => CameraPosition.Front,
        CameraType.Back => CameraPosition.Back,
        _ => CameraPosition.Unknow
      };
      foreach (CameraInfo cam in CameraViw.Cameras)
      {
        if (cam.Position != pos) continue;
        CameraViw.Camera = cam;
        break;
      }
    }
    if (CameraViw.Camera is null)
    {
      InvokeCameraNotFound(CameraType);
      return;
    }
    if (AutoStart) await StartAsync();
  }

  private void CameraViw_BarcodeDetected(object sender, BarcodeEventArgs args)
  {
    string res = CameraViw.BarCodeResults[0].Text;
    if (res.Equals(previous)) return;
    previous = res;
    OnBarcodeDetected?.Invoke(this, res);
  }

  #endregion

  #region private static

  private static void DrawCorner(ICanvas canvas, float x, float y, float width, float height)
  {
    canvas.DrawLine(x, y, x + width, y);
    canvas.DrawLine(x, y, x, y + height);
  }

  private static void OnGraphicsOverlayChange(BindableObject obj, object o, object n) => ((CameraView)obj).GraphicsOverlay?.Invalidate();

  #endregion
}