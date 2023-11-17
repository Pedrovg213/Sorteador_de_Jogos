using Mopups.Services;
using SeletorJogo.ModelosVisuais;
using SeletorJogo.PopUps;

namespace SeletorJogo.Paginas;

public partial class InicialPagina : ContentPage
{
	private ListaJogosMV viewModel;

	public InicialPagina ()
	{
		InitializeComponent( );

		viewModel = new( );
		BindingContext = viewModel;
	}

	private void OcultarVerticalLayout ( VerticalStackLayout _layout ) =>
		_layout.IsVisible = !_layout.IsVisible;

	private async void Tbi_EnviarDoacao_Clicked ( object sender, EventArgs e )
	{
		await MopupService.Instance.PushAsync( new DoacaoPopUp( ) );
	}

	private void Tbi_OcultarEsperando_Clicked ( object sender, EventArgs e )
	{
		OcultarVerticalLayout( vslEsperando );

		ocultarEsperando.Text =
			vslEsperando.IsVisible
			? "Ocultar jogos em espera"
			: "Mostrar jogos em espera";
	}
	private void Tbi_OcultarIniciados_Clicked ( object sender, EventArgs e )
	{
		OcultarVerticalLayout( vslIniciados );

		ocultarIniciados.Text =
			vslIniciados.IsVisible
			? "Ocultar jogos iniciados"
			: "Mostrar jogos iniciados";
	}
	private void Tbi_OcultarZerados_Clicked ( object sender, EventArgs e )
	{
		OcultarVerticalLayout( vslZerados );

		ocultarZerados.Text =
			vslZerados.IsVisible
			? "Ocultar jogos zerados"
			: "Mostrar jogos zerados";
	}

	private void Tbi_MostrarTodos_Clicked ( object sender, EventArgs e )
	{
		vslEsperando.IsVisible = true;
		vslIniciados.IsVisible = true;
		vslZerados.IsVisible = true;

		ocultarEsperando.Text = "Ocultar jogos em espera";
		ocultarIniciados.Text = "Ocultar jogos iniciados";
		ocultarZerados.Text = "Ocultar jogos zerados";
	}
}