using SeletorJogo.BasedeDados;

namespace SeletorJogo;

public partial class App : Application
{
	public App ()
	{
		InitializeComponent( );

		MainPage = new AppShell( );

		JogosBaseDados.IniciarBaseDeDados( );

	}

	protected override Window CreateWindow ( IActivationState activationState )
	{
		Window window =  base.CreateWindow( activationState );

		window.Width = 700;
		window.MinimumWidth = 700;
		window.MaximumWidth = 700;

		return window;
	}
}
