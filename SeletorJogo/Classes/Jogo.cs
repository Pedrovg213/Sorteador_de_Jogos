using SeletorJogo.BasedeDados;
using SeletorJogo.Extensoes;

namespace SeletorJogo.Classes;
public class Jogo
{
	public bool Zerado
	{
		get; set;
	}
	public bool Iniciado
	{
		get; set;
	}

	public string Name
	{
		get; set;
	}
	public string Identidade
	{
		get; set;
	}


	public Jogo ()
	{
		if (string.IsNullOrEmpty( Identidade ))
			Identidade = Identidade.GerarId( );
	}
	public Jogo ( string _name ) : this( )
	{
		Name = _name;
		//AtualizarJogo( );
	}


	public void AtualizarJogo () =>
		 JogosBaseDados.AdicionarJogo( this );

	public string GetName () =>
		 Name;
	public void MarcarSeZerado ( bool _value )
	{
		Iniciado = !_value;
		Zerado = _value;
		AtualizarJogo( );
	}

	public override bool Equals ( object obj )
	{
		Jogo other = (Jogo)obj;
		return Identidade.Equals( other.Identidade );
	}
	public override int GetHashCode () =>
		 Identidade.GetHashCode( );
}
