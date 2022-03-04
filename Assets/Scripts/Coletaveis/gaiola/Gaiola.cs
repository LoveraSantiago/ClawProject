public class Gaiola : GO
{
    public static GaiolaContexto contexto;
    public string coletavelPreso { get; private set; }

    public Gaiola() 
        : base(contexto, contexto.nomeador.getName()) {}

    protected override GOContexto getGOContext()
    {
        return contexto;
    }

    public static void configurar(ContextoDto contextoDto)
    {
        contexto = new GaiolaContexto(contextoDto);
    }

    public void aprisionarColetavel(string nome)
    {
        coletavelPreso = nome;
    }

    public bool isVazia()
    {
        return coletavelPreso == null;
    }

    public bool isNaoVazia()
    {
        return !isVazia();
    }    

    public override void desligar()
    {
        base.desligar();
        coletavelPreso = null;
    }
}
