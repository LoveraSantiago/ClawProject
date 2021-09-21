using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayCacaNiquel : AcaoCacaNiquel.ProdutorEvento
{
    private AbstractLevel.TIPO_GAME tipoGame;
    private ProdutorDeEvento<CacaNiquelResult> produtorDeEvento;
    private InputGame inputGame;

    public DisplayCacaNiquel(InputGame inputGame)
    {
        this.inputGame = inputGame;
        produtorDeEvento = new ProdutorDeEvento<CacaNiquelResult>();
    }

    public void configuradoPeloLevel(AbstractLevel.TIPO_GAME tipoGame)
    {
        this.tipoGame = tipoGame;
    }

    public void iniciar(GrupoDisplays grupoDisplays)
    {
        if (AbstractLevel.isCacaNiquelLevel(tipoGame))
        {
            Utils.MonoBehaviour.StartCoroutine(iniciarDisplayCacaNiquel(grupoDisplays));
        }
    }   

    private IEnumerator iniciarDisplayCacaNiquel(GrupoDisplays grupoDisplays)
    {
        yield return new WaitForSeconds(0.5f);
        produtorDeEvento.produziuEvento(new CacaNiquelResult());
        grupoDisplays.ligarGlowLuz();    

        Sprite[][] allSrites = montarSpritesTipoCacaNiquel(grupoDisplays.displaysSlotsDto);
        grupoDisplays.ligarCacaNiquel(allSrites[0], allSrites[1], allSrites[2]);
        yield return new WaitForSeconds(0.1f);

        int clicado = 0;
        while(clicado < 3)
        {
            if (inputGame.aconteceuTap())
            {                
                grupoDisplays.pararCacaNiquel(clicado, allSrites[clicado], getSprDeSucesso());
                clicado++;
            }            
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        Sprite[] resultados = grupoDisplays.getResultadosCacaNiquel();
        avaliarResultados(resultados, grupoDisplays);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("PupScene");
    }    

    private Sprite[][] montarSpritesTipoCacaNiquel(DisplaysSlotsDto displaysSlotsDto)
    {
        if(tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL)
        {
            int indicePup = PlayerPrefsPup.recuperarIndicePup();
            PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

            Sprite[] spritesSlot1 = new Sprite[] { pupEscolhido.sprPowerUp, displaysSlotsDto.SprVazio };
            Sprite[] spritesSlot2 = new Sprite[] { pupEscolhido.sprPowerUp, displaysSlotsDto.SprVazio };
            Sprite[] spritesSlot3 = new Sprite[] { pupEscolhido.sprPowerUp, displaysSlotsDto.SprVazio, displaysSlotsDto.SprMoeda };

            Sprite[][] allSrites = new Sprite[][] { spritesSlot1, spritesSlot2, spritesSlot3 };
            return allSrites;
        }
        else
        {
            Sprite[] sprites = FactoryPowerUpEntidade.getAllSpritesPowerUp();
            Sprite[][] allSprites = new Sprite[][] { sprites, sprites, sprites };
            return allSprites;
        }
    }

    private Sprite getSprDeSucesso()
    {
        if(tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL)
        {
            int indicePup = PlayerPrefsPup.recuperarIndicePup();
            PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
            return pupEscolhido.sprPowerUp;
        }
        else
        {
            return null;
        }
    }

    private void avaliarResultados(Sprite[] resultados, GrupoDisplays grupoDisplays)
    {
        if (tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL)
        {
            int indicePup = PlayerPrefsPup.recuperarIndicePup();
            PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

            if (resultados[2] == grupoDisplays.displaysSlotsDto.SprMoeda)
            {
                grupoDisplays.ligarGlowLuz();
            }
            else if (resultados[0] == pupEscolhido.sprPowerUp &&
                    resultados[1] == pupEscolhido.sprPowerUp &&
                    resultados[2] == pupEscolhido.sprPowerUp)
            {
                grupoDisplays.ligar();
            }
            else
            {
                grupoDisplays.ligarGlowFail();
            }
        }
    }        

    ProdutorDeEvento<CacaNiquelResult> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
