using SeletorJogo.Classes;
using System.Text.Json;

namespace SeletorJogo.BasedeDados;
public static class JogosBaseDados
{
	private static readonly string pastaCaminho = FileSystem.AppDataDirectory + "\\Data";
	private static readonly string arquivoCaminho = pastaCaminho + "\\Jogos.txt";

	private static List<Jogo> jogos = new();


	private static void CriarPasta ()
	{
		if (!Directory.Exists( pastaCaminho ))
			Directory.CreateDirectory( pastaCaminho );
	}

	private static void AtualizarJogo ( Jogo _jogo )
	{
		if (jogos.Contains( _jogo ))
		{
			int index = jogos.IndexOf(_jogo);
			jogos[index] = _jogo;
			SalvarArquivo( );
		}
	}

	public static void SalvarArquivo ()
	{
		CriarPasta( );

		string infosSerializadas = JsonSerializer.Serialize(jogos);

		File.WriteAllText( arquivoCaminho, infosSerializadas );
	}

	public static void CarregarArquivo ()
	{
		CriarPasta( );

		if (File.Exists( arquivoCaminho ))
		{
			string infosLidas = File.ReadAllText(arquivoCaminho);

			if (!string.IsNullOrEmpty( infosLidas ))
				jogos = JsonSerializer.Deserialize<List<Jogo>>( infosLidas );
		}
	}

	public static void IniciarBaseDeDados () =>
		 CarregarArquivo( );

	public static List<Jogo> PegarJogos () =>
		 jogos;

	public static void AdicionarJogo ( Jogo _jogo )
	{
		if (!jogos.Contains( _jogo ))
		{
			jogos.Add( _jogo );
			SalvarArquivo( );
		} else
			AtualizarJogo( _jogo );
	}

	public static void ExcluirJogo ( Jogo _jogo )
	{
		jogos.Remove( _jogo );
		SalvarArquivo( );
	}

	public static async Task AdicionarDadosDeArquivo ( IEnumerable<FileResult> _arquivos )
	{
		List<string> newLines = new();
		foreach (FileResult fileResult in _arquivos)
		{
			if (fileResult != null)
			{
				if (fileResult.FileName.EndsWith( "txt", StringComparison.OrdinalIgnoreCase ))
				{
					using Stream stream = await fileResult.OpenReadAsync();
					using StreamReader streamReader = new(stream);

					bool fimStream = false;

					while (!fimStream)
					{
						string line = streamReader.ReadLine( );
						newLines.Add( line );

						fimStream = streamReader.EndOfStream;
					}
				}
			}
		}

		foreach (string strg in newLines)
			AdicionarJogo( new Jogo( strg ) );
	}
}
