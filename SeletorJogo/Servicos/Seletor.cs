using SeletorJogo.Classes;
using SeletorJogo.ModelosVisuais;
using System.Collections.ObjectModel;

namespace SeletorJogo.Servicos;
public static class Seletor
{
	public static JogoMV SelecionarJogoAleatorio ( ObservableCollection<JogoMV> _jogos )
	{
		if (_jogos.Count <= 0)
			return null;

		Random random = new ();
		int index = random.Next(0, _jogos.Count);

		return _jogos[index];
	}

}
