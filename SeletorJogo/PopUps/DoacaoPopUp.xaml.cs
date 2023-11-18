using Mopups.Services;

namespace SeletorJogo.PopUps;

public partial class DoacaoPopUp
{
	public DoacaoPopUp ()
	{
		InitializeComponent( );

		copiarBtn.Clicked += Btn_Copiar_Clicked;
		cancelarBtn.Clicked += CancelarBtn_Clicked;
	}

	private async void Btn_Copiar_Clicked ( object sender, EventArgs e )
	{
		string codigo = "b137d027-3a15-4a05-aefb-d8209fb7e668";

		if (Clipboard.Default.HasText)
			await Clipboard.Default.SetTextAsync( null );

		await Clipboard.Default.SetTextAsync( codigo );
	}

	private async void CancelarBtn_Clicked ( object sender, EventArgs e )
	{
		if (MopupService.Instance.PopupStack.Count > 0)
			await MopupService.Instance.PopAsync( );
	}
}