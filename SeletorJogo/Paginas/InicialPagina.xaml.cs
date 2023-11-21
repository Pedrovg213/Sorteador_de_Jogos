using Mopups.Services;
using SeletorJogo.ModelosVisuais;
using SeletorJogo.PopUps;

namespace SeletorJogo.Paginas;

public partial class InicialPagina : ContentPage
{
	private readonly ListaJogosMV viewModel;

	public InicialPagina ()
	{
		InitializeComponent( );

		viewModel = new( );
		BindingContext = viewModel;
	}

	private void OcultarVerticalLayout ( CollectionView _layout ) =>
		_layout.IsVisible = !_layout.IsVisible;

	private async void Btn_EnviarDoacao_Clicked ( object sender, EventArgs e )
	{
		await MopupService.Instance.PushAsync( new DoacaoPopUp( ) );
	}

	private void Btn_OcultarEsperando_Clicked ( object sender, EventArgs e )
	{
		OcultarVerticalLayout( clvEsperando );

		btnEsperando.Text =
			clvEsperando.IsVisible
			? "Ocultar"
			: "Mostrar";
	}
	private void Btn_OcultarIniciados_Clicked ( object sender, EventArgs e )
	{
		OcultarVerticalLayout( clvIniciados );

		btnIniciados.Text =
			clvIniciados.IsVisible
			? "Ocultar"
			: "Mostrar";
	}
	private void Btn_OcultarZerados_Clicked ( object sender, EventArgs e )
	{
		OcultarVerticalLayout( clvZerados );

		btnZerados.Text =
			clvZerados.IsVisible
			? "Ocultar"
			: "Mostrar";
	}

	private void Btn_OcultarTodos_Clicked ( object sender, EventArgs e )
	{
		clvEsperando.IsVisible = false;
		clvIniciados.IsVisible = false;
		clvZerados.IsVisible = false;

		btnEsperando.Text = "Mostrar";
		btnIniciados.Text = "Mostrar";
		btnZerados.Text = "Mostrar";
	}

	private void Btn_MostrarTodos_Clicked ( object sender, EventArgs e )
	{
		clvEsperando.IsVisible = true;
		clvIniciados.IsVisible = true;
		clvZerados.IsVisible = true;

		btnEsperando.Text = "Ocultar";
		btnIniciados.Text = "Ocultar";
		btnZerados.Text = "Ocultar";
	}
}