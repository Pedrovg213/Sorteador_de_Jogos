using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Mopups.Services;

namespace SeletorJogo;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp ()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>( )
			.ConfigureMopups( )
			.ConfigureFonts( fonts =>
			{
				fonts.AddFont( "OpenSans-Regular.ttf", "OpenSansRegular" );
				fonts.AddFont( "OpenSans-Semibold.ttf", "OpenSansSemibold" );
			} );

#if DEBUG
		builder.Logging.AddDebug( );
#endif

		builder.Services.AddSingleton( MopupService.Instance );

		return builder.Build( );
	}
}
