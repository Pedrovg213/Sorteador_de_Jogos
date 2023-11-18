using Mopups.Services;
using SeletorJogo.ModelosVisuais;

namespace SeletorJogo.PopUps;

public partial class AtualizadorPopUp
{
	private JogoMV jogoMV;

	public AtualizadorPopUp () =>
		InitializeComponent( );

	public AtualizadorPopUp ( JogoMV _jogoMV ) : this( )
	{
		okBtn.Clicked += AtualizarJogo;
		okBtn.Clicked += FecharPopUp;
		cacelarBtn.Clicked += FecharPopUp;

		jogoMV = _jogoMV;

		entName.Text = jogoMV.Nome;
		pckEstado.SelectedIndex = (int)jogoMV.Estado;
	}
	private async void FecharPopUp ( object sender, EventArgs e )
	{
		if (MopupService.Instance.PopupStack.Count > 0)
			await MopupService.Instance.PopAsync( );
	}
	private void AtualizarJogo ( object sender, EventArgs e ) =>
		jogoMV.AtualizarJogo( entName.Text, (JogoMV.EstadoJogo)pckEstado.SelectedIndex );
}