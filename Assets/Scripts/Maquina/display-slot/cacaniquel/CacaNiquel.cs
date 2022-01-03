using UnityEngine;

public class CacaNiquel 
{
    private string tipoGame;

    public void configuradoPeloLevel(string tipoGame)
    {
        this.tipoGame = tipoGame;
    }

    public Sprite[][] montarSpritesTipoCacaNiquel(DisplaysSlotsDto displaysSlotsDto)
    {
        if (LevelUtils.isCacaNiquelSingleLevel(tipoGame))
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

    public CacaNiquelResultadoEnum[] montarResultados(PowerUpEntidade pupEscolhido, Sprite[] resultadosSprs, DisplaysSlotsDto displaysSlotsDto)
    {
        CacaNiquelResultadoEnum[] resultados = new CacaNiquelResultadoEnum[] {
            avaliarResultado(pupEscolhido, resultadosSprs[0], displaysSlotsDto),
            avaliarResultado(pupEscolhido, resultadosSprs[1], displaysSlotsDto),
            avaliarResultado(pupEscolhido, resultadosSprs[2], displaysSlotsDto)};

        return resultados;
    }

    private CacaNiquelResultadoEnum avaliarResultado(
        PowerUpEntidade pupEscolhido, Sprite sprSorteado, DisplaysSlotsDto displaysSlotsDto)
    {
        if (sprSorteado == pupEscolhido.sprPowerUp)
        {
            return CacaNiquelResultadoEnum.SUCESSO;
        }
        else if (sprSorteado == displaysSlotsDto.SprVazio)
        {
            return CacaNiquelResultadoEnum.FAIL;
        }
        else
        {
            return CacaNiquelResultadoEnum.COIN;
        }
    }
}
