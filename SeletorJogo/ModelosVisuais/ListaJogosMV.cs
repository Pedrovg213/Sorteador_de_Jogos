﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using SeletorJogo.BasedeDados;
using SeletorJogo.Classes;
using SeletorJogo.PopUps;
using SeletorJogo.Servicos;
using System.Collections.ObjectModel;

namespace SeletorJogo.ModelosVisuais;
public partial class ListaJogosMV : BaseMV
{
	private readonly ObservableCollection<JogoMV> todosJogos = new ();


	[ObservableProperty]
	private ObservableCollection<JogoMV> jogosAJogarMV = new ();
	[ObservableProperty]
	private ObservableCollection<JogoMV> jogosIniciadosMV = new();
	[ObservableProperty]
	private ObservableCollection<JogoMV> jogosZeradosMV = new ();
	[ObservableProperty]
	private int jogosAJogarQuant;
	[ObservableProperty]
	private int jogosIniciadosQuant;
	[ObservableProperty]
	private int jogosZeradosQuant;


	public ListaJogosMV () =>
		Inicializacao( );

	private void Inicializacao ()
	{
		List<Jogo> jogos = JogosBaseDados.PegarJogos();

		for (int i = 0 ; i < jogos.Count ; i++)
			todosJogos.Add( new JogoMV( jogos[i], this ) );

		InicializarJogos( );
	}
	private JogoMV SortearJogo () =>
		Seletor.SelecionarJogoAleatorio( JogosAJogarMV );

	private void AdicionarJogo ( string _nomeJogo )
	{
		if (string.IsNullOrEmpty( _nomeJogo ))
			return;

		Jogo jogo = new (_nomeJogo);
		jogo.AtualizarJogo( );

		JogoMV jogoMV =  new( jogo, this );

		todosJogos.Add( jogoMV );

		ReordenarJogos( jogoMV );
	}

	[RelayCommand]
	private async Task AbrirSeletorArquivo ()
	{
		FilePickerFileType fileType = new (new Dictionary<DevicePlatform, IEnumerable<string>>
		{
			{ DevicePlatform.WinUI, new[]{".txt"} },
		});

		PickOptions options = new ()
		{
			PickerTitle = "Selecione um arquivo .txt, cada linha do arquivo será considerado um jogo a parte.",
			FileTypes = fileType,
		};

		IEnumerable<FileResult> resultados = await FilePicker.Default.PickMultipleAsync(options);
		await JogosBaseDados.AdicionarDadosDeArquivo( resultados );

		Inicializacao( );
	}

	[RelayCommand]
	private async Task AbrirAdicionarJogo ()
	{
		await MopupService.Instance.PushAsync(
			 new AdicionarJogoPopUp(
					( s, e ) => AdicionarJogo( (s as Entry).Text ) ) );
	}

	[RelayCommand]
	private async Task AbrirSorteadorPopUp ()
	{
		JogoMV jogo = SortearJogo();

		if (jogo != null)
			await MopupService.Instance.PushAsync( new SorteadoPopUp(
				jogo,
				( s, e ) =>
				{
					jogo.Estado = JogoMV.EstadoJogo.Iniciado;
					jogo.AtualizarJogo( );
				},
				async ( s, e ) => await AbrirSorteadorPopUp( ) ) );
		else
			await MopupService.Instance.PushAsync( new SemJogoParaSorteioPopUp(
				async ( s, e ) => await AbrirAdicionarJogo( ) ) );
	}


	public void ExcluirJogo ( JogoMV _jogo )
	{
		todosJogos.Remove( _jogo );

		if (JogosAJogarMV.Remove( _jogo ))
			JogosAJogarQuant--;
		else if (JogosIniciadosMV.Remove( _jogo ))
			JogosIniciadosQuant--;
		else if (JogosZeradosMV.Remove( _jogo ))
			JogosZeradosQuant--;
	}
	public void ReordenarJogos ( JogoMV _jogo )
	{
		if (_jogo.Estado == JogoMV.EstadoJogo.Esperando)
		{
			if (JogosIniciadosMV.Remove( _jogo ))
				JogosIniciadosQuant = JogosIniciadosMV.Count;
			if (JogosZeradosMV.Remove( _jogo ))
				JogosZeradosQuant = JogosZeradosMV.Count;

			if (!JogosAJogarMV.Contains( _jogo ))
				JogosAJogarMV.Add( _jogo );

			JogosAJogarMV = new ObservableCollection<JogoMV>( JogosAJogarMV.OrderBy( j => j.Nome ) );
			JogosAJogarQuant = JogosAJogarMV.Count;

		} else if (_jogo.Estado == JogoMV.EstadoJogo.Iniciado)
		{
			if (JogosAJogarMV.Remove( _jogo ))
				JogosAJogarQuant = JogosAJogarMV.Count;
			if (JogosZeradosMV.Remove( _jogo ))
				JogosZeradosQuant = JogosZeradosMV.Count;

			if (!JogosIniciadosMV.Contains( _jogo ))
				JogosIniciadosMV.Add( _jogo );

			JogosIniciadosMV = new ObservableCollection<JogoMV>( JogosIniciadosMV.OrderBy( j => j.Nome ) );
			JogosIniciadosQuant = JogosIniciadosMV.Count;

		} else if (_jogo.Estado == JogoMV.EstadoJogo.Zerado)
		{
			if (JogosAJogarMV.Remove( _jogo ))
				JogosAJogarQuant = JogosAJogarMV.Count;
			if (JogosIniciadosMV.Remove( _jogo ))
				JogosIniciadosQuant = JogosIniciadosMV.Count;

			if (!JogosZeradosMV.Contains( _jogo ))
				JogosZeradosMV.Add( _jogo );

			JogosZeradosMV = new ObservableCollection<JogoMV>( JogosZeradosMV.OrderBy( j => j.Nome ) );
			JogosZeradosQuant = JogosZeradosMV.Count;
		}
	}

	private void InicializarJogos ()
	{
		ObservableCollection<JogoMV> jogosJogar = new (todosJogos.Where(j => j.Estado == JogoMV.EstadoJogo.Esperando));
		JogosAJogarMV = new ( jogosJogar.OrderBy( j => j.Nome ) );
		JogosAJogarQuant = JogosAJogarMV.Count;

		ObservableCollection<JogoMV> jogosIniciados = new (todosJogos.Where(j =>j.Estado == JogoMV.EstadoJogo.Iniciado));
		JogosIniciadosMV = new ( jogosIniciados.OrderBy( j => j.Nome ) );
		JogosIniciadosQuant = JogosIniciadosMV.Count;

		ObservableCollection<JogoMV> jogosZerados = new (todosJogos.Where(j => j.Estado == JogoMV.EstadoJogo.Zerado));
		JogosZeradosMV = new ( jogosZerados.OrderBy( j => j.Nome ) );
		JogosZeradosQuant = JogosZeradosMV.Count;
	}
}
