using Mopups.Services;

namespace SeletorJogo.PopUps;

public partial class AdicionarJogoPopUp
{
	public AdicionarJogoPopUp () =>
		InitializeComponent( );

	public AdicionarJogoPopUp ( EventHandler _okBotaoClick ) : this( )
	{
		okBtn.Clicked += ( s, e ) => _okBotaoClick( nameEntry, EventArgs.Empty );
		okBtn.Clicked += CancelarBtn_Clicked;
		cancelarBtn.Clicked += CancelarBtn_Clicked;

		FocarEntry( );
	}

	private async void CancelarBtn_Clicked ( object sender, EventArgs e )
	{
		if (MopupService.Instance.PopupStack.Count > 0)
			await MopupService.Instance.PopAsync( );
	}

	private void FocarEntry ()
	{
		nameEntry.Focus( );
		nameEntry.CursorPosition = 0;
	}
}