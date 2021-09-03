using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayCacaNiquel : AcaoCacaNiquel.ProdutorEvento
{
    private bool acionarCacaNiquel;
    private ProdutorDeEvento<Vazio> produtorDeEvento;
    private InputGame inputGame;

    public DisplayCacaNiquel(InputGame inputGame)
    {
        this.inputGame = inputGame;
        produtorDeEvento = new ProdutorDeEvento<Vazio>();
    }

    public void configuradoPeloLevel(AbstractLevel.TIPO_GAME tipoGame)
    {        
        if(tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL)
        {
            acionarCacaNiquel = true;            
        }
    }

    public void iniciar(GrupoDisplays grupoDisplays)
    {
        if (acionarCacaNiquel)
        {
            Utils.MonoBehaviour.StartCoroutine(iniciarDisplayCacaNiquel(grupoDisplays));
        }
    }

    private IEnumerator iniciarDisplayCacaNiquel(GrupoDisplays grupoDisplays)
    {
        yield return new WaitForSeconds(0.5f);
        produtorDeEvento.produziuEvento(new Vazio());
        grupoDisplays.ligarGlowLuz();

        int indicePup = PlayerPrefsUtils.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        Sprite[] spritesSlot1 = new Sprite[] { pupEscolhido.sprPowerUp, grupoDisplays.displaysSlotsDto.SprVazio };
        Sprite[] spritesSlot2 = new Sprite[] { pupEscolhido.sprPowerUp, grupoDisplays.displaysSlotsDto.SprVazio };
        Sprite[] spritesSlot3 = new Sprite[] { pupEscolhido.sprPowerUp, grupoDisplays.displaysSlotsDto.SprVazio, grupoDisplays.displaysSlotsDto.SprMoeda };

        grupoDisplays.ligarCacaNiquel(spritesSlot1, spritesSlot2, spritesSlot3);
        yield return new WaitForSeconds(0.1f);

        int clicado = 0;
        Sprite[][] allSrites = new Sprite[][] { spritesSlot1, spritesSlot2, spritesSlot3 };
        while(clicado < 3)
        {
            if (inputGame.aconteceuTap())
            {                
                grupoDisplays.pararCacaNiquel(clicado, allSrites[clicado], pupEscolhido.sprPowerUp);
                clicado++;
            }            
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        Sprite[] resultados = grupoDisplays.getResultadosCacaNiquel();
        if(resultados[2] == grupoDisplays.displaysSlotsDto.SprMoeda)
        {
            grupoDisplays.ligarGlowLuz();
        }
        else if(resultados[0] == pupEscolhido.sprPowerUp &&
                resultados[1] == pupEscolhido.sprPowerUp &&
                resultados[2] == pupEscolhido.sprPowerUp)
        {
            grupoDisplays.ligar();
        }
        else
        {
            grupoDisplays.ligarGlowFail();
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("PupScene");
    }    

    ProdutorDeEvento<Vazio> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
