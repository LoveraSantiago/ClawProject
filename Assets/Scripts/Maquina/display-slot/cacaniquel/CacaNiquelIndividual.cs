using UnityEngine;

public class CacaNiquelIndividual : AbstractCacaNiquel
{
    public CacaNiquelIndividual(CacaNiquelDto cacaNiquelDto)
        : base(cacaNiquelDto){}

    public override Sprite[][] montarSpritesTipoCacaNiquel()
    {
        int indicePup = PlayerPrefsPup.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        Sprite sprPowerUp = pupEscolhido.sprPowerUp;
        Sprite sprVazio   = cacaNiquelDto.SprVazio;
        Sprite sprMoeda   = cacaNiquelDto.SprMoeda;

        Sprite[] spritesSlot1 = new Sprite[] { sprPowerUp, sprVazio };
        Sprite[] spritesSlot2 = new Sprite[] { sprPowerUp, sprVazio };
        Sprite[] spritesSlot3 = new Sprite[] { sprPowerUp, sprVazio, sprMoeda };

        Sprite[][] allSrites = new Sprite[][] { spritesSlot1, spritesSlot2, spritesSlot3 };
        return allSrites;
    }

    public override Sprite getSprDeSucesso()
    {
        int indicePup = PlayerPrefsPup.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
        return pupEscolhido.sprPowerUp;
    }

    public override void passarResultadosParaGrupoDisplay(PowerUpEntidade pupEscolhido, Sprite[] resultados, GrupoDisplays grupoDisplays)
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

    public override CacaNiquelEventoDto montarResultado(PowerUpEntidade pupEscolhido, Sprite spriteEscolhido)
    {
        CacaNiquelResultadoEnum resultado = avaliarResultado(pupEscolhido, spriteEscolhido);
        CacaNiquelEventoDto eventoEmAndamento = CacaNiquelEventoDto.ofEmAndamento(resultado);
        return eventoEmAndamento;
    }

    protected override CacaNiquelEventoDto getEvento(Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados)
    {
        return CacaNiquelEventoDto.ofSingle(sprResultados, resultados);
    }    
}
