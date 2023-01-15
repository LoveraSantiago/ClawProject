using UnityEngine;

public abstract class AbstractCacaNiquel 
{   
    protected CacaNiquelDto cacaNiquelDto;

    public AbstractCacaNiquel(CacaNiquelDto cacaNiquelDto)
    {
        this.cacaNiquelDto = cacaNiquelDto;
    }

    public abstract Sprite[][] montarSpritesTipoCacaNiquel();
    public abstract Sprite getSprDeSucesso();    

    public abstract CacaNiquelEventoDto montarResultado(PowerUpEntidade pupEscolhido, SomCacaNiquel somCacaNiquel, Sprite spriteEscolhido);

    public CacaNiquelEventoDto montarResultados(
        PowerUpEntidade pupEscolhido, SomCacaNiquel somCacaNiquel, Sprite[] resultadosSprs)
    {
        CacaNiquelResultadoEnum[] resultados = new CacaNiquelResultadoEnum[] {
            avaliarResultado(pupEscolhido, resultadosSprs[0]),
            avaliarResultado(pupEscolhido, resultadosSprs[1]),
            avaliarResultado(pupEscolhido, resultadosSprs[2])};

        CacaNiquelEventoDto evento = getEvento(resultadosSprs, resultados);            
        return evento;
    }    

    protected abstract CacaNiquelEventoDto getEvento(Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados);

    protected CacaNiquelResultadoEnum avaliarResultado(
       PowerUpEntidade pupEscolhido, Sprite sprSorteado)
    {
        return avaliarResultado(pupEscolhido, null, sprSorteado);
    }

    protected CacaNiquelResultadoEnum avaliarResultado(
        PowerUpEntidade pupEscolhido, SomCacaNiquel somCacaNiquel, Sprite sprSorteado)
    {
        if (sprSorteado == pupEscolhido.sprIconPowerUp)
        {
            if(somCacaNiquel != null)
            {
                somCacaNiquel.playSomCacaNiquelSucesso();
            }
            return CacaNiquelResultadoEnum.SUCESSO;
        }
        else if (sprSorteado == cacaNiquelDto.SprVazio)
        {
            if(somCacaNiquel != null)
            {
                somCacaNiquel.playSomCacaNiquelFail();
            }
            return CacaNiquelResultadoEnum.FAIL;
        }
        else
        {
            if(somCacaNiquel != null)
            {
                somCacaNiquel.playSomCacaNiquelCoin();
            }
            return CacaNiquelResultadoEnum.COIN;
        }
    }
}
