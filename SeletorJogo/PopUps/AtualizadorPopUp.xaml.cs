using Mopups.Services;
using SeletorJogo.ModelosVisuais;

namespace SeletorJogo.PopUps;

public partial class AtualizadorPopUp
{
	public AtualizadorPopUp () =>
		InitializeComponent( );

	public AtualizadorPopUp ( JogoMV _jogoMV, EventHandler _okButtonClick ) : this( )
	{
		BindingContext = _jogoMV;
		cacelarBtn.Clicked += CancelarBtn_Clicked;
	}
	private void CancelarBtn_Clicked ( object sender, EventArgs e ) =>
		MopupService.Instance.PopAsync( );
}