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
	public Jogo ( string _name ) : this( ) =>
		Name = _name;


	public void AtualizarJogo ( string _name, bool _iniciado, bool _zerado )
	{
		Name = _name;

		MarcarSeIniciado( _iniciado );
		MarcarSeZerado( _zerado );

		JogosBaseDados.AtualizarJogo( this );
	}
	public void AtualizarJogo () =>
		JogosBaseDados.AdicionarJogo( this );


	public void MarcarSeZerado ( bool _value )
	{
		Zerado = _value;
		if (_value)
			Iniciado = false;
	}

	public void MarcarSeIniciado ( bool _value )
	{
		Iniciado = _value;
		if (_value)
			Zerado = false;
	}

	public override bool Equals ( object obj )
	{
		Jogo other = (Jogo)obj;
		return Identidade.Equals( other.Identidade );
	}
	public override int GetHashCode () =>
		 Identidade.GetHashCode( );
}
