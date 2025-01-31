namespace Cephei.Libraries.Maui.Camera
{
  /// <summary>
  /// The CameraNotFoundException is thrown when the system attempts to start a CameraView without a valid camera.
  /// </summary>
  public class CameraNotFoundException : CameraException
  {
    internal CameraNotFoundException(CameraView view, CameraType type) : this(view, type
      , $"The system failed to find a camera of type ({type}).")
    { }
    internal CameraNotFoundException(CameraView view, CameraType type, string message) : base(view, message)
      => Type = type;

    #region public

    /// <summary>
    /// The camera type that was requested.
    /// </summary>
    public readonly CameraType Type;

    #endregion
  }
}
