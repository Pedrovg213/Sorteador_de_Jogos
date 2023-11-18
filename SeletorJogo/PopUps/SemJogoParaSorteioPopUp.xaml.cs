using Mopups.Services;

namespace SeletorJogo.PopUps;

public partial class SemJogoParaSorteioPopUp
{
	public SemJogoParaSorteioPopUp () =>
		InitializeComponent( );

	public SemJogoParaSorteioPopUp ( EventHandler _adicionarBotaoClick ) : this( )
	{
		adicionarBtn.Clicked += CancelarBtn_Clicked;
		adicionarBtn.Clicked += _adicionarBotaoClick;
		cancelarBtn.Clicked += CancelarBtn_Clicked;
	}
	private async void CancelarBtn_Clicked ( object sender, EventArgs e )
	{
		if (MopupService.Instance.PopupStack.Count > 0)
			await MopupService.Instance.PopAsync( );
	}
}