using System.Reflection;
using Microsoft.Extensions.Logging;

namespace maui_issue6_xaml_datatype_warnings;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		PrintDotnetInfo();
		return builder.Build();
	}

	private static void PrintDotnetInfo()
	{
		var root = Assembly.GetExecutingAssembly().Location;
		var assemblyPath = Path.Combine(Path.GetDirectoryName(root)!, "Microsoft.Maui.Controls.dll");
		Console.WriteLine($"Assembly path: {assemblyPath}");
		var assembly = Assembly.LoadFile(assemblyPath);
		var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
		var productVersion = fileVersionInfo.ProductVersion;
		Console.WriteLine($"Product version: {productVersion}");
		var mauiVersion = assembly.GetName().Version?.ToString();
		Console.WriteLine($"Maui version: {mauiVersion}");
		var dotnetVersion = Environment.Version;
		Console.WriteLine($"Dotnet version: {dotnetVersion}");
		var runtimeVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
		Console.WriteLine($"Runtime version: {runtimeVersion}");
	}
}
