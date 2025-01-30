using Cephei.Maui.Camera;
using Cephei.Maui.Lottie;
using Microsoft.Extensions.Logging;

namespace Cephei.Maui.Testing
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
      builder
        .UseMauiApp<App>()
        .UseCepheiCamera()
        .UseCepheiLottie()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });

#if DEBUG
  		builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
