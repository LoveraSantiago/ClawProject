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
        while (coletavelSelecionado == null)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                coletavelSelecionado = ColetavelHit.hit(inputGame);
                if (coletavelSelecionado != null)
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
}
