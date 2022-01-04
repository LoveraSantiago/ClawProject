using UnityEngine;

public abstract class AbstractCacaNiquel 
{   
    private CacaNiquelDto cacaNiquelDto;

    public AbstractCacaNiquel(CacaNiquelDto cacaNiquelDto)
    {
        this.cacaNiquelDto = cacaNiquelDto;
    }  

    public Sprite[][] montarSpritesTipoCacaNiquel()
    {
        if (LevelUtils.isCacaNiquelSingleLevel(tipoGame))
        {
            int indicePup = PlayerPrefsPup.recuperarIndicePup();
            PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

            Sprite[] spritesSlot1 = new Sprite[] { pupEscolhido.sprPowerUp, cacaNiquelDto.SprVazio};
            Sprite[] spritesSlot2 = new Sprite[] { pupEscolhido.sprPowerUp, cacaNiquelDto.SprVazio};
            Sprite[] spritesSlot3 = new Sprite[] { pupEscolhido.sprPowerUp, cacaNiquelDto.SprVazio, cacaNiquelDto.SprMoeda};

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

    public Sprite getSprDeSucesso()
    {
        if (LevelUtils.isCacaNiquelSingleLevel(tipoGame))
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

    public void passarResultadosParaGrupoDisplay(PowerUpEntidade pupEscolhido, Sprite[] resultados, GrupoDisplays grupoDisplays)
    {
        if (LevelUtils.isCacaNiquelSingleLevel(tipoGame))
        {
            if (resultados[2] == cacaNiquelDto.SprMoeda)
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

    public CacaNiquelEventoDto montarResultados(PowerUpEntidade pupEscolhido, Sprite[] resultadosSprs)
    {
        CacaNiquelResultadoEnum[] resultados = new CacaNiquelResultadoEnum[] {
            avaliarResultado(pupEscolhido, resultadosSprs[0]),
            avaliarResultado(pupEscolhido, resultadosSprs[1]),
            avaliarResultado(pupEscolhido, resultadosSprs[2])};

        CacaNiquelEventoDto evento = new CacaNiquelEventoDto(tipoGame, resultadosSprs, resultados);
        return evento;
    }

    private CacaNiquelResultadoEnum avaliarResultado(PowerUpEntidade pupEscolhido, Sprite sprSorteado)
    {
        if (sprSorteado == pupEscolhido.sprPowerUp)
        {
            return CacaNiquelResultadoEnum.SUCESSO;
        }
        else if (sprSorteado == cacaNiquelDto.SprVazio)
        {
            return CacaNiquelResultadoEnum.FAIL;
        }
        else
        {
            return CacaNiquelResultadoEnum.COIN;
        }
    }
}
