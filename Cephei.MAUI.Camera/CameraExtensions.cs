using Camera.MAUI;

namespace Cephei.MAUI.Camera
{
  /// <summary>
  /// The CameraExtensions class contains extension methods related to MAUI cameras.
  /// </summary>
  public static class CameraExtensions
  {
    /// <summary>
    /// Builds the application to use the MAUI Camera.
    /// </summary>
    /// <param name="builder">The application's builder.</param>
    /// <returns>The application builder.</returns>
    public static MauiAppBuilder UseCepheiCamera(this MauiAppBuilder builder) => builder.UseMauiCameraView();
  }
}
