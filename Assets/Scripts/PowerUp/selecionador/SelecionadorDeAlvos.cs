using System.Collections;
using System.Collections.Generic;

public class SelecionadorDeAlvos 
{
    public Coletavel coletavelSelecionado { get; private set; }
    private List<Coletavel> coletaveisJaSelecionados;

    public SelecionadorDeAlvos()
    {
        coletaveisJaSelecionados = new List<Coletavel>();
    }

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
        coletavelSelecionado = null;
        Coletavel coletavel = null;
        while (coletavelSelecionado == null)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                coletavel = ColetavelHit.hit(inputGame);
                if (coletavel != null && isColetavelNaoSelecionadoAntes(coletavel))
                {
                    coletavelSelecionado = coletavel;
                }
            }
            yield return null;
        }
        yield return null;
    }    

    private bool isColetavelNaoSelecionadoAntes(Coletavel coletavel)
    {
        return !coletaveisJaSelecionados.Contains(coletavel);        
    }
}
