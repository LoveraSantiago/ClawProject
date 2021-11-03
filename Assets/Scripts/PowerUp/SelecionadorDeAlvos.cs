using System.Collections;

public class SelecionadorDeAlvos 
{
    public ColetavelTile coletavelAcertado { get; private set; }

    public IEnumerator selecionarAlvo(InputGame inputGame)
    {        
        while (coletavelAcertado == null)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                coletavelAcertado = ColetavelHit.hit(inputGame);
                if (coletavelAcertado != null)
                {
                    string nomeAlvo = coletavelAcertado.nome;
                    ColetavelHelper coletaveisHelper = new ColetavelHelper();
                    coletaveisHelper.ligarMiraAlvoFinalNoColetavel(nomeAlvo);                
                }
            }
            yield return null;
        }
        yield return null;
    }
}
