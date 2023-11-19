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

	public enum EstadoJogo
	{
		Esperando,
		Iniciado,
		Zerado
	}

	[ObservableProperty]
	private string nome;
	[ObservableProperty]
	private EstadoJogo estado;
	[ObservableProperty]
	private bool zeradoCheckBox;


	public JogoMV ( Jogo _jogo, ListaJogosMV _listaJogosMV )
	{
		jogo = _jogo;
		Nome = _jogo.Name;

		SetarEstadoJogo( _jogo.Iniciado, _jogo.Zerado );

		listaJogosMV = _listaJogosMV;
	}


	private void ReordenarJogos ()
	{
		if (listaJogosMV != null)
			listaJogosMV.ReordenarJogos( this );
	}

	private void SetarEstadoJogo ( bool _inidicado, bool _zerado )
	{
		if (!_inidicado && !_zerado)
			Estado = EstadoJogo.Esperando;
		else if (_inidicado)
			Estado = EstadoJogo.Iniciado;
		else if (_zerado)
			Estado = EstadoJogo.Zerado;

		ZeradoCheckBox = Estado == EstadoJogo.Zerado;
	}
	partial void OnZeradoCheckBoxChanged ( bool value )
	{
		SetarEstadoJogo( !value, value );

		AtualizarJogo( );
	}

	public void AtualizarJogo ()
	{
		bool iniciado = Estado == EstadoJogo.Iniciado;
		bool zerado = Estado == EstadoJogo.Zerado;

		if (Estado != EstadoJogo.Esperando)
			ZeradoCheckBox = Estado == EstadoJogo.Zerado;

		jogo.AtualizarJogo( Nome, iniciado, zerado );
		ReordenarJogos( );
	}
	public async void AtualizarJogo ( string _nome, EstadoJogo _estado )
	{
		await Application.Current.MainPage.DisplayAlert( "Estado", _estado.ToString( ), "Ok" );
		Estado = _estado;
		Nome = _nome;

		AtualizarJogo( );
	}

	[RelayCommand]
	private void ExlcluirJogo ()
	{
		JogosBaseDados.ExcluirJogo( jogo );
		listaJogosMV.ExcluirJogo( this );
	}

	[RelayCommand]
	private async Task AbrirAtualizadorJogo ()
	{
		await MopupService.Instance.PushAsync( new AtualizadorPopUp( this ) );
	}
}
