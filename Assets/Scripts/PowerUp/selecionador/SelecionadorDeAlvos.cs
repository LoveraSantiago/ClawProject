using System.Collections;

public class SelecionadorDeAlvos 
{
    public Coletavel coletavelSelecionado { get; private set; }    

    public SelecionadorDeAlvos ligarMiras()
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis();
        return this;
    }

    public SelecionadorDeAlvos ligarMiraFinal()
    {
        if(coletavelSelecionado != null)
        {
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            helperInGame.ligarMiraAlvoFinalNoColetavel(coletavelSelecionado.nome);
        }
        return this;
    }

    public IEnumerator selecionarAlvo(InputGame inputGame)
    {
        return selecionarAlvoDiferenteDe(inputGame, "");
    }

    public IEnumerator selecionarAlvoDiferenteDe(InputGame inputGame, string nome)
    {
        coletavelSelecionado = null;
        Coletavel coletavel = null;
        while (coletavelSelecionado == null)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                coletavel = ColetavelHit.hit(inputGame);
                if (coletavel != null && isNotEqualsColetavel(coletavel, nome))
                {
                    coletavelSelecionado = coletavel;
                }                
            }
            yield return null;
        }
        yield return null;
    }

    private bool isNotEqualsColetavel(Coletavel coletavel, string nome)
    {
        return !coletavel.nome.Equals(nome);
    }
}
