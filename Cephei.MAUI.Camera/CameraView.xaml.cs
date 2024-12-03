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
    CameraView.BarcodeDetected += CameraView_BarcodeDetected;
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
  public CameraInfo Camera => CameraView.Camera;

  /// <summary>
  /// Gets or sets the overlay color. Default is transparent black.
  /// </summary>
  public Color OverlayColor
  {
    set
    {
      color_over = value;
      GraphicsOverlay.Invalidate();
    }
    get => color_over;
  }

  /// <summary>
  /// Gets or sets the overlay corner color. Default is white.
  /// </summary>
  public Color OverlayCornerColor
  {
    set
    {
      color_line = value;
      GraphicsOverlay.Invalidate();
    }
    get => color_line;
  }

  /// <summary>
  /// Specifies the camera type that will be used by this CameraView (if it is a front or back camera).
  /// </summary>
  public CameraType CameraType { set; get; } = CameraType.Any;

  /// <summary>
  /// Gets or sets the camera's width.
  /// </summary>
  /// <remarks>Must be set or the application will silently crash.</remarks>
  public double CameraWidth
  {
    set
    {
      CameraView.WidthRequest = value;
      GraphicsOverlay.WidthRequest = value;
      GraphicsOverlay.Invalidate();
    }
    get => CameraView.WidthRequest;
  }

  /// <summary>
  /// Gets or sets the camera's height.
  /// </summary>
  /// <remarks>Must be set or the application will silently crash.</remarks>
  public double CameraHeight
  {
    set
    {
      CameraView.HeightRequest = value;
      GraphicsOverlay.HeightRequest = value;
      GraphicsOverlay.Invalidate();
    }
    get => CameraView.HeightRequest;
  }

  /// <summary>
  /// Gets or sets the overlay's uncovered width. Setting it to 0 or less will disable the overlay.
  /// </summary>
  public float OverlayWidth
  {
    set
    {
      over_w = value;
      GraphicsOverlay.Invalidate();
    }
    get => over_w;
  }

  /// <summary>
  /// Gets or sets the overlay's uncovered height. Setting it to 0 or less will disable the overlay.
  /// </summary>
  public float OverlayHeight
  {
    set
    {
      over_h = value;
      GraphicsOverlay.Invalidate();
    }
    get => over_h;
  }

  /// <summary>
  /// Gets or sets the overlay's corner width. Default is 16.
  /// </summary>
  public float OverlayCornerWidth
  {
    set
    {
      corner_w = value;
      GraphicsOverlay.Invalidate();
    }
    get => corner_w;
  }

  /// <summary>
  /// Gets or sets the overlay's corner height. Default is 16.
  /// </summary>
  public float OverlayCornerHeight
  {
    set
    {
      corner_h = value;
      GraphicsOverlay.Invalidate();
    }
    get => corner_h;
  }

  /// <summary>
  /// Gets or sets the overlay's corner size. Setting this overrides both corner width and height.
  /// </summary>
  public float OverlayCornerSize
  {
    set
    {
      corner_w = value * 0.5f;
      OverlayCornerHeight = corner_w;
    }
    get => OverlayCornerWidth + OverlayCornerHeight;
  }

  /// <summary>
  /// Gets or sets the overlay's corner thickness. Default is 4.
  /// </summary>
  public float OverlayCornerThickness
  {
    set
    {
      corner_t = value;
      GraphicsOverlay.Invalidate();
    }
    get => corner_t;
  }

  /// <summary>
  /// Determines the camera's detection cooldown (in miliseconds).
  /// </summary>
  public int DetectionCooldown { get; set; } = 5000;

  /// <summary>
  /// Should the camera automatically start when the device's cameras are loaded?
  /// </summary>
  public bool AutoStart { get; set; } = true;

  /// <summary>
  /// Keep the screen on while the camera is active?
  /// </summary>
  public bool KeepScreenOn { get; set; } = true;

  /// <summary>
  /// Enables or disables the camera's barcode scanning.
  /// </summary>
  public bool BarcodeScanning
  {
    set => CameraView.BarCodeDetectionEnabled = value;
    get => CameraView.BarCodeDetectionEnabled;
  }

  // METHODS

  /// <summary>
  /// Starts the camera. Does nothing if the Camera property is null.
  /// </summary>
  /// <exception cref="CameraOperationException"></exception>
  public async Task StartAsync()
  {
    if (CameraView.Camera is null) return;
    HandleCameraResult(await CameraView.StartCameraAsync());
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
    if (CameraView.Camera is null) return;
    HandleCameraResult(await CameraView.StopCameraAsync());
    if (KeepScreenOn) DeviceDisplay.Current.KeepScreenOn = false;
  }

  #endregion

  #region private

  // FIELDS

  private Color color_over = new(0, 0, 0, 120);
  private Color color_line = new(1f);
  private string previous = "";
  private float over_w = 0f, over_h = 0f;
  private float corner_w = 16f, corner_h = 16f, corner_t = 4f;

  // METHODS

  #endregion

  #region private static

  private static void DrawCorner(ICanvas canvas, float x, float y, float width, float height)
  {
    canvas.DrawLine(x, y, x + width, y);
    canvas.DrawLine(x, y, x, y + height);
  }

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

  private async void CameraView_CamerasLoaded(object sender, EventArgs e)
  {
    if (CameraView.NumCamerasDetected < 1)
    {
      InvokeCameraNotFound(CameraType);
      return;
    }
    if (CameraType == CameraType.Any) CameraView.Camera = CameraView.Cameras.FirstOrDefault();
    else
    {
      CameraPosition pos = CameraType switch
      {
        CameraType.Front => CameraPosition.Front,
        CameraType.Back => CameraPosition.Back,
        _ => CameraPosition.Unknow
      };
      foreach (CameraInfo cam in CameraView.Cameras)
      {
        if (cam.Position != pos) continue;
        CameraView.Camera = cam;
        break;
      }
    }
    if (CameraView.Camera is null)
    {
      InvokeCameraNotFound(CameraType);
      return;
    }
    if (AutoStart) await StartAsync();
  }

  private void CameraView_BarcodeDetected(object sender, BarcodeEventArgs args)
  {
    string res = CameraView.BarCodeResults[0].Text;
    if (res.Equals(previous)) return;
    previous = res;
    OnBarcodeDetected?.Invoke(this, res);
  }

  #endregion
}