using UnityEngine;

public class Gaiola : GO
{
    public static GaiolaContexto contexto;
    public string nomeColetavelPreso { get; private set; }

    public Gaiola() 
        : base(contexto, "G" + contexto.nomeador.getName()) {}

    protected override GOContexto getGOContext()
    {
        return contexto;
    }

    public static void configurar(GameObject goMainGaiola)
    {
        contexto = new GaiolaContexto(goMainGaiola);
    }

    public void aprisionarColetavel(string nome)
    {
        nomeColetavelPreso = nome;
    }

    private void soltarColetavel()
    {
        if (isNaoVazia())
        {            
            Coletavel coletavelPreso = HelperColetaveisInGame.getColetavelInGameByGoName(nomeColetavelPreso);
            coletavelPreso.soltar();
            coletavelPreso.desafixarVerticalmente();
            coletavelPreso.ligarAnimacaoIdle();
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
