using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Cephei.MAUI.Lottie
{
  /// <summary>
  /// The LottieExtensions class contains extension methods related with Lottie views.
  /// </summary>
  public static class LottieExtensions
  {
    /// <summary>
    /// Builds the app using Cephei Lottie builder. It uses SkiaSharp.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <returns>The application builder configured to use SkiaSharp.</returns>
    public static MauiAppBuilder UseCepheiLottie(this MauiAppBuilder builder) => builder.UseSkiaSharp();
  }
}
