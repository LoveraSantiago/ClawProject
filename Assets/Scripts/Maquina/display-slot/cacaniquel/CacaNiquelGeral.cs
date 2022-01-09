using UnityEngine;

public class CacaNiquelGeral : AbstractCacaNiquel
{
    public CacaNiquelGeral(CacaNiquelDto cacaNiquelDto) 
        : base(cacaNiquelDto){}

    public override Sprite[][] montarSpritesTipoCacaNiquel()
    {
        Sprite[] sprites = PowerUpHelper.getAllSpritesPowerUp();
        Sprite[][] allSprites = new Sprite[][] { sprites, sprites, sprites };
        return allSprites;
    }

    public override Sprite getSprDeSucesso()
    {
        return null;
    }

    public override void passarResultadosParaGrupoDisplay(PowerUpEntidade pupEscolhido, Sprite[] resultados, GrupoDisplays grupoDisplays)
    {        
    }

    public override CacaNiquelEventoDto montarResultado(PowerUpEntidade pupEscolhido, Sprite spriteEscolhido)
    {
        return CacaNiquelEventoDto.ofEmAndamento(CacaNiquelResultadoEnum.SUCESSO);
    }

    protected override CacaNiquelEventoDto getEvento(Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados)
    {
        return CacaNiquelEventoDto.ofGeral(sprResultados, resultados);
    }
}
