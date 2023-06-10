using CommunityToolkit.Maui;
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
			.UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5100"
            : "http://localhost:5100" )});


        builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddSingleton<IUserService, UserService>();

		builder.Services.AddTransient<ServerOverview>();
		builder.Services.AddTransient<ServerOverviewViewModel>();
		builder.Services.AddSingleton<IServerService, ServerService>();

		builder.Services.AddTransient<ServerDetails>();
		builder.Services.AddTransient<ServerDetailsViewModel>();

		builder.Services.AddTransient<Feedback>();
		builder.Services.AddSingleton<FeedbackViewModel>();
		builder.Services.AddScoped<IFeedbackService, FeedbackService>();

		builder.Services.AddTransient<Users>();
		builder.Services.AddSingleton<UserViewModel>();

		builder.Services.AddTransient<UserDetails>();
		builder.Services.AddTransient<UserDetailsViewModel>();

		builder.Services.AddTransient<CreateUser>();
		builder.Services.AddTransient<CreateUserViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
