using System.Collections;
using UnityEngine;

public class DisplayCacaNiquel : AcaoCacaNiquel.ProdutorEvento
{
    public enum RESULTADO_CACANIQUEL { SUCESSO, FAIL, COIN };

    private string tipoGame;
    private ProdutorDeEvento<CacaNiquelResult> produtorDeEvento;
    private InputGame inputGame;

    public DisplayCacaNiquel(InputGame inputGame)
    {
        this.inputGame = inputGame;
        produtorDeEvento = new ProdutorDeEvento<CacaNiquelResult>();
    }

    public void configuradoPeloLevel(string tipoGame)
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

        DisplaysSlotsDto displaysSlotsDto = grupoDisplays.displaysSlotsDto;
        Sprite[][] allSrites = montarSpritesTipoCacaNiquel(displaysSlotsDto);
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
        Sprite[] resultadosSprs = grupoDisplays.getResultadosCacaNiquel();

        int indicePup = PlayerPrefsPup.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        avaliarResultados(pupEscolhido, resultadosSprs, grupoDisplays);
        RESULTADO_CACANIQUEL[] resultados = new RESULTADO_CACANIQUEL[] {
            avaliarResultado(pupEscolhido, resultadosSprs[0], displaysSlotsDto),
            avaliarResultado(pupEscolhido, resultadosSprs[1], displaysSlotsDto),
            avaliarResultado(pupEscolhido, resultadosSprs[2], displaysSlotsDto)};

        produtorDeEvento.produziuEvento(new CacaNiquelResult(tipoGame, resultadosSprs, resultados));       
    }    

    private Sprite[][] montarSpritesTipoCacaNiquel(DisplaysSlotsDto displaysSlotsDto)
    {
        if(AbstractLevel.isCacaNiquelSingleLevel(tipoGame))        
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
            Sprite[] sprites = PowerUpHelper.getAllSpritesPowerUp();
            Sprite[][] allSprites = new Sprite[][] { sprites, sprites, sprites };
            return allSprites;
        }
    }

    private Sprite getSprDeSucesso()
    {
        if(AbstractLevel.isCacaNiquelSingleLevel(tipoGame))        
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

    private void avaliarResultados(PowerUpEntidade pupEscolhido , Sprite[] resultados, GrupoDisplays grupoDisplays)
    {
        if (AbstractLevel.isCacaNiquelSingleLevel(tipoGame))
        {
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

    private RESULTADO_CACANIQUEL avaliarResultado(
        PowerUpEntidade pupEscolhido, Sprite sprSorteado, DisplaysSlotsDto displaysSlotsDto)
    {
        if(sprSorteado == pupEscolhido.sprPowerUp)
        {
            return RESULTADO_CACANIQUEL.SUCESSO;
        }
        else if(sprSorteado == displaysSlotsDto.SprVazio)
        {
            return RESULTADO_CACANIQUEL.FAIL;
        }
        else
        {
            return RESULTADO_CACANIQUEL.COIN;
        }
    }

    ProdutorDeEvento<CacaNiquelResult> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
