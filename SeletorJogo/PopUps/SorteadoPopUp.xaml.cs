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

	private async void CancelarBtn_Clicked ( object sender, EventArgs e )
	{
		if (MopupService.Instance.PopupStack.Count > 0)
			await MopupService.Instance.PopAsync( );
	}
}