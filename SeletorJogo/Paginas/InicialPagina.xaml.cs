using SeletorJogo.ModelosVisuais;

namespace SeletorJogo.Paginas;

public partial class InicialPagina : ContentPage
{
    private ListaJogosMV viewModel;

    public InicialPagina()
    {
        InitializeComponent();

        viewModel = new();
        BindingContext = viewModel;
    }
}