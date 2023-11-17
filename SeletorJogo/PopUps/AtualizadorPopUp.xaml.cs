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
		okBtn.Clicked += _okButtonClick;
		okBtn.Clicked += CancelarBtn_Clicked;
		cacelarBtn.Clicked += CancelarBtn_Clicked;
	}
	private void CancelarBtn_Clicked ( object sender, EventArgs e ) =>
		MopupService.Instance.PopAsync( );
}