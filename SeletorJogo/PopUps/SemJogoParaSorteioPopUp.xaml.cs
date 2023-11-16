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
	private void CancelarBtn_Clicked ( object sender, EventArgs e ) =>
		MopupService.Instance.PopAsync( );
}