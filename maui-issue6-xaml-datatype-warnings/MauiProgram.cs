using System.Reflection;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace maui_issue6_xaml_datatype_warnings;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		PrintDotnetInfo();
		return builder.Build();
	}

	private static void PrintDotnetInfo()
	{
#pragma warning disable IL3000
		var root = Assembly.GetExecutingAssembly().Location;
#pragma warning restore IL3000
		var assemblyPath = Path.Combine(Path.GetDirectoryName(root)!, "Microsoft.Maui.Controls.dll");
		Console.WriteLine($"Assembly path: {assemblyPath}");
		var assembly = Assembly.LoadFile(assemblyPath);
#pragma warning disable IL3000
		var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
#pragma warning restore IL3000
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
