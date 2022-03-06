public class Gaiola : GO
{
    public static GaiolaContexto contexto;
    public string nomeColetavelPreso { get; private set; }

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
        nomeColetavelPreso = nome;
    }

    private void soltarColetavel()
    {
        if (isNaoVazia())
        {
            HelperColetaveisInGame coletaveisInGame = new HelperColetaveisInGame();
            Coletavel coletavelPreso = coletaveisInGame.getColetavelInGameByGoName(nomeColetavelPreso);
            coletavelPreso.soltar();
            coletavelPreso.desafixarVerticalmente();
            coletavelPreso.desligarAnimacao();
        }
        nomeColetavelPreso = null;
    }

    private bool isVazia()
    {
        return nomeColetavelPreso == null;
    }

    private bool isNaoVazia()
    {
        return !isVazia();
    }

    public override void desligar()
    {
        base.desligar();
        soltarColetavel();
    }
}
