using CommunityToolkit.Mvvm.ComponentModel;

namespace SeletorJogo.ModelosVisuais;
public partial class BaseMV : ObservableObject
{
	[ObservableProperty]
	protected bool isRefresh;
}
