using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using SeletorJogo.BasedeDados;
using SeletorJogo.Classes;
using SeletorJogo.PopUps;

namespace SeletorJogo.ModelosVisuais;
public partial class JogoMV : BaseMV
{
	private Jogo jogo;
	private ListaJogosMV listaJogosMV;


	[ObservableProperty]
	private string nome;
	[ObservableProperty]
	private bool zerado;
	[ObservableProperty]
	private bool iniciado;



	public JogoMV ( Jogo _jogo, ListaJogosMV _listaJogosMV )
	{
		jogo = _jogo;
		Nome = _jogo.Name;
		Iniciado = _jogo.Iniciado;
		Zerado = _jogo.Zerado;
		listaJogosMV = _listaJogosMV;
	}


	private void ReordenarJogos ()
	{
		if (listaJogosMV != null)
			listaJogosMV.ReordenarJogos( this );
	}

	partial void OnNomeChanged ( string value )
	{
		jogo.Name = value;

		ReordenarJogos( );
	}

	partial void OnIniciadoChanged ( bool value )
	{
		jogo.MarcarSeZerado( !value );

		Zerado = !value;

		ReordenarJogos( );
	}
	partial void OnZeradoChanged ( bool value )
	{
		jogo.MarcarSeZerado( value );

		Iniciado = !value;

		ReordenarJogos( );
	}

	public string PegaId () =>
		 jogo.Identidade;

	[RelayCommand]
	private void ExlcluirJogo ()
	{
		JogosBaseDados.ExcluirJogo( jogo );
		listaJogosMV.ExcluirJogo( this );
	}

	[RelayCommand]
	private async Task AbrirAtualizadorJogo ()
	{
		await MopupService.Instance.PushAsync( new AtualizadorPopUp( this,
			( s, e ) => ReordenarJogos( ) ) );
	}
}
