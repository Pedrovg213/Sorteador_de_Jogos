using Mopups.Services;
using SeletorJogo.ModelosVisuais;

namespace SeletorJogo.PopUps;

public partial class SorteadoPopUp
{
	public SorteadoPopUp () =>
		InitializeComponent( );

	public SorteadoPopUp ( JogoMV _jogoMV, EventHandler _okBotaoClick, EventHandler _trocarBotaoClick ) : this( )
	{
		BindingContext = _jogoMV;

		okBtn.Clicked += _okBotaoClick;
		okBtn.Clicked += CancelarBtn_Clicked;
		trocarBtn.Clicked += CancelarBtn_Clicked;
		trocarBtn.Clicked += _trocarBotaoClick;
		cancelarBtn.Clicked += CancelarBtn_Clicked;
	}

	private void CancelarBtn_Clicked ( object sender, EventArgs e ) =>
		MopupService.Instance.PopAsync( );
}