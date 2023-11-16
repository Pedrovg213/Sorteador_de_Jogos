using Mopups.Services;

namespace SeletorJogo.PopUps;

public partial class AdicionarJogoPopUp
{
	public AdicionarJogoPopUp ()
	{
		InitializeComponent( );
		nameEntry.Focus( );
		nameEntry.SelectionLength = 0;
	}

	public AdicionarJogoPopUp ( EventHandler _okBotaoClick ) : this( )
	{
		okBtn.Clicked += ( s, e ) => _okBotaoClick( nameEntry, EventArgs.Empty );
		okBtn.Clicked += CancelarBtn_Clicked;
		cancelarBtn.Clicked += CancelarBtn_Clicked;
	}

	private void CancelarBtn_Clicked ( object sender, EventArgs e ) =>
		MopupService.Instance.PopAsync( );
}