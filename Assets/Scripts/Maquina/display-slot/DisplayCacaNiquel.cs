using System.Collections;
using UnityEngine;

public class DisplayCacaNiquel : AcaoCacaNiquel.ProdutorEvento
{
    public enum RESULTADO_CACANIQUEL { SUCESSO, FAIL, COIN };

    private string tipoGame;
    private ProdutorDeEvento<CacaNiquelResultadoDto> produtorDeEvento;
    private CacaNiquel cacaNiquel;
    private InputGame inputGame;

    public DisplayCacaNiquel(InputGame inputGame)
    {
        this.inputGame = inputGame;
        produtorDeEvento = new ProdutorDeEvento<CacaNiquelResultadoDto>();
        cacaNiquel = new CacaNiquel();
    }

    public void configuradoPeloLevel(string tipoGame)
    {
        this.tipoGame = tipoGame;
        cacaNiquel.configuradoPeloLevel(tipoGame);
    }

    public void iniciar(GrupoDisplays grupoDisplays)
    {
        if (LevelUtils.isCacaNiquelLevel(tipoGame))
        {
            Utils.MonoBehaviour.StartCoroutine(iniciarDisplayCacaNiquel(grupoDisplays));
        }
    }   

    private IEnumerator iniciarDisplayCacaNiquel(GrupoDisplays grupoDisplays)
    {
        yield return new WaitForSeconds(0.5f);
        produtorDeEvento.produziuEvento(new CacaNiquelResultadoDto());
        grupoDisplays.ligarGlowLuz();

        DisplaysSlotsDto displaysSlotsDto = grupoDisplays.displaysSlotsDto;
        Sprite[][] allSrites = cacaNiquel.montarSpritesTipoCacaNiquel(displaysSlotsDto);
        grupoDisplays.ligarCacaNiquel(allSrites[0], allSrites[1], allSrites[2]);
        yield return new WaitForSeconds(0.1f);

        int clicado = 0;
        while(clicado < 3)
        {
            if (inputGame.aconteceuTap())
            {                
                grupoDisplays.pararCacaNiquel(clicado, allSrites[clicado], cacaNiquel.getSprDeSucesso());
                clicado++;
            }            
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        Sprite[] resultadosSprs = grupoDisplays.getResultadosCacaNiquel();

        int indicePup = PlayerPrefsPup.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        cacaNiquel.passarResultadosParaGrupoDisplay(pupEscolhido, resultadosSprs, grupoDisplays);
        RESULTADO_CACANIQUEL[] resultados = cacaNiquel.montarResultados(pupEscolhido, resultadosSprs, displaysSlotsDto);

        produtorDeEvento.produziuEvento(new CacaNiquelResultadoDto(tipoGame, resultadosSprs, resultados));       
    }       

    ProdutorDeEvento<CacaNiquelResultadoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
