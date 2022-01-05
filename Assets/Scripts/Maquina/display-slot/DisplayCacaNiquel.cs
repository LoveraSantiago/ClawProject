using System.Collections;
using UnityEngine;

public class DisplayCacaNiquel : AcaoCacaNiquel.ProdutorEvento
{   
    private ProdutorDeEvento<CacaNiquelEventoDto> produtorDeEvento;
    private AbstractCacaNiquel cacaNiquel;    

    public DisplayCacaNiquel()
    {   
        produtorDeEvento = new ProdutorDeEvento<CacaNiquelEventoDto>();        
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido, CacaNiquelDto cacaNiquelDto)
    {
        if (LevelUtils.isCacaNiquelGeralLevel(levelEscolhido))
        {
            cacaNiquel = new CacaNiquelGeral(cacaNiquelDto);
        }
        else
        {
            cacaNiquel = new CacaNiquelIndividual(cacaNiquelDto);
        }        
    }

    public void iniciar(GrupoDisplays grupoDisplays, InputGame inputGame)
    {   
        Utils.MonoBehaviour.StartCoroutine(iniciarDisplayCacaNiquel(grupoDisplays, inputGame));
    }   

    private IEnumerator iniciarDisplayCacaNiquel(GrupoDisplays grupoDisplays, InputGame inputGame)
    {
        yield return new WaitForSeconds(0.5f);
        produtorDeEvento.produziuEvento(new CacaNiquelEventoDto());
        grupoDisplays.ligarGlowLuz();

        DisplaysSlotsDto displaysSlotsDto = grupoDisplays.displaysSlotsDto;
        Sprite[][] allSrites = cacaNiquel.montarSpritesTipoCacaNiquel();
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

        CacaNiquelEventoDto evento = cacaNiquel.montarResultados(pupEscolhido, resultadosSprs);        
        produtorDeEvento.produziuEvento(evento);       
    }       

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
