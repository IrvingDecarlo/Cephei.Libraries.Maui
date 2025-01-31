using Camera.MAUI;

namespace Cephei.Libraries.Maui.Camera
{
  /// <summary>
  /// The CameraOperationException is thrown when the camera attempts to perform an operation (start or stop) and it fails.
  /// </summary>
  public class CameraOperationException : CameraException
  {
    internal CameraOperationException(CameraView view, CameraResult result) : this(view, result
      , $"The camera failed to perform the operation (Result: {result}).")
    { }
    internal CameraOperationException(CameraView view, CameraResult result, string message) : base(view, message)
      => Result = result;

    #region public

    /// <summary>
    /// The operation's result.
    /// </summary>
    public readonly CameraResult Result;

    #endregion
  }
}
