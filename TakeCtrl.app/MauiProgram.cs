using Microsoft.Extensions.Logging;
using TakeCtrl.app.Communication;
using TakeCtrl.app.Communication.Contracts;
using TakeCtrl.app.View;
using TakeCtrl.app.ViewModel;

namespace TakeCtrl.app;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddSingleton<IUserService, UserService>();

		builder.Services.AddTransient<ServerOverview>();
		builder.Services.AddTransient<ServerOverviewViewModel>();
		builder.Services.AddSingleton<IServerService, ServerService>();

		builder.Services.AddTransient<ServerDetails>();
		builder.Services.AddTransient<ServerDetailsViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
