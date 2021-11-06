using System.Collections;

public class SelecionadorDeAlvos 
{
    public ColetavelTile coletavelSelecionado { get; private set; }    

    public IEnumerator selecionarAlvo(InputGame inputGame)
    {
        return selecionarAlvoDiferenteDe(inputGame, "");
    }

    public IEnumerator selecionarAlvoDiferenteDe(InputGame inputGame, string nome)
    {
        coletavelSelecionado = null;
        ColetavelTile coletavel = null;
        while (coletavelSelecionado == null)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                coletavel = ColetavelHit.hit(inputGame);
                if (coletavel != null &&
                    isNotEqualsColetavel(coletavel, nome))
                {
                    coletavelSelecionado = coletavel;
                }                
            }
            yield return null;
        }
        yield return null;
    }

    private bool isNotEqualsColetavel(ColetavelTile coletavel, string nome)
    {
        return !coletavel.nome.Equals(nome);
    }
}
