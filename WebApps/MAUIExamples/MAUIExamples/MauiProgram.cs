using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using MAUIExamples.Core.Services;
using MAUIExamples.Database;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace MAUIExamples
{
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
				});

			builder.Services.AddMauiBlazorWebView();
			builder.Services.AddSingleton<IFolderPicker>(FolderPicker.Default);
			builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
			builder.Services.AddSingleton<ExcelService>();
			builder.Services.AddSingleton<CarService>();
			builder.Services.AddSingleton<TodoItemDatabase>();
			builder.Services.AddMudServices();

#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
