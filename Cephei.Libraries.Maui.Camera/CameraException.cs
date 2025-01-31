namespace Cephei.Libraries.Maui.Camera
{
  /// <summary>
  /// The CameraException is thrown when the camera throws any kind of exception from within its scope.
  /// </summary>
  public class CameraException : Exception
  {
    internal CameraException(CameraView view, string message) : base(message)
      => CameraView = view;

    #region public

    /// <summary>
    /// Reference to the CameraView that threw the exception.
    /// </summary>
    public readonly CameraView CameraView;

    #endregion
  }
}
