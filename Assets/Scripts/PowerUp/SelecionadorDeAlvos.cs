using System.Collections;

public class SelecionadorDeAlvos 
{
    public ColetavelTile coletavelSelecionado { get; private set; }

    public void ligarMirasNosColetaveis()
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.ligarMirasNosColetaveis();
    }

    public IEnumerator selecionarAlvo(InputGame inputGame)
    {
        return selecionarAlvoDiferenteDe(inputGame, "");
    }

    public IEnumerator selecionarAlvoDiferenteDe(InputGame inputGame, string nome)
    {
        coletavelSelecionado = null;
        while (coletavelSelecionado == null)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                coletavelSelecionado = ColetavelHit.hit(inputGame);
                if (coletavelSelecionado != null &&
                    isNotEqualsColetavel(coletavelSelecionado, nome))
                {
                    string nomeAlvo = coletavelSelecionado.nome;
                    ColetavelHelper coletaveisHelper = new ColetavelHelper();
                    coletaveisHelper.ligarMiraAlvoFinalNoColetavel(nomeAlvo);
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
