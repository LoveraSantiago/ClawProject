using UnityEngine;

public class CacaNiquelIndividual : AbstractCacaNiquel
{
    public CacaNiquelIndividual(CacaNiquelDto cacaNiquelDto)
        : base(cacaNiquelDto){}

    public override Sprite[][] montarSpritesTipoCacaNiquel()
    {
        int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        Sprite sprPowerUp = pupEscolhido.sprIconPowerUp;
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
        int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
        return pupEscolhido.sprIconPowerUp;
    }    

    public override CacaNiquelEventoDto montarResultado(PowerUpEntidade pupEscolhido, SomCacaNiquel somCacaNiquel, Sprite spriteEscolhido)
    {
        CacaNiquelResultadoEnum resultado = avaliarResultado(pupEscolhido, spriteEscolhido);
        switch (resultado)
        {
            case CacaNiquelResultadoEnum.SUCESSO: somCacaNiquel.playSomCacaNiquelSucesso(); break;
            case CacaNiquelResultadoEnum.FAIL   : somCacaNiquel.playSomCacaNiquelFail();    break;
            case CacaNiquelResultadoEnum.COIN   : somCacaNiquel.playSomCacaNiquelCoin();    break;
        }
        CacaNiquelEventoDto eventoEmAndamento = CacaNiquelEventoDto.ofEmAndamento(resultado);
        return eventoEmAndamento;
    }

    protected override CacaNiquelEventoDto getEvento(Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados)
    {
        return CacaNiquelEventoDto.ofSingle(sprResultados, resultados);
    }    
}
