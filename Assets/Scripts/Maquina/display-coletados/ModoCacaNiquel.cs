using System.Collections;
using UnityEngine;

public class ModoCacaNiquel : AcaoCacaNiquel.ProdutorEvento
{   
    private ProdutorDeEvento<CacaNiquelEventoDto> produtorDeEvento;
    private AbstractCacaNiquel cacaNiquel;    

    public ModoCacaNiquel()
    {   
        produtorDeEvento = new ProdutorDeEvento<CacaNiquelEventoDto>();        
    }

    public void configuradoPeloLevel(CacaNiquelDto cacaNiquelDto, SomCacaNiquel somCacaNiquel)
    {
        if (LevelUtils.isCacaNiquelGeralLevel())
        {
            somCacaNiquel.playSomBackgroundCacaNiquel();
            cacaNiquel = new CacaNiquelGeral(cacaNiquelDto);
        }
        else
        {
            somCacaNiquel.playSomBackgroundCacaNiquel();
            cacaNiquel = new CacaNiquelIndividual(cacaNiquelDto);
        }        
    }

    public void iniciar(GrupoDisplays grupoDisplays, SomCacaNiquel somCacaNiquel, InputGame inputGame)
    {
        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(iniciarDisplayCacaNiquel(grupoDisplays, somCacaNiquel, inputGame));
    }   

    private IEnumerator iniciarDisplayCacaNiquel(GrupoDisplays grupoDisplays, SomCacaNiquel somCacaNiquel, InputGame inputGame)
    {
        yield return new WaitForSeconds(0.5f);
        CacaNiquelEventoDto eventoInicio = new CacaNiquelEventoDto();
        produtorDeEvento.produziuEvento(eventoInicio);        
        
        Sprite[][] allSrites = cacaNiquel.montarSpritesTipoCacaNiquel();
        grupoDisplays.ligarCacaNiquel(allSrites[0], allSrites[1], allSrites[2]);
        yield return new WaitForSeconds(0.1f);

        int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        int clicado = 0;
        somCacaNiquel.iniciarSomSlotsMovimento();
        while(clicado < 3)
        {
            if (inputGame.aconteceuTap())
            {                
                grupoDisplays.pararSlotCacaNiquel(clicado, allSrites[clicado], cacaNiquel.getSprDeSucesso());

                Sprite sprSorteado = grupoDisplays.getResultadoCacaNiquel(clicado);
                CacaNiquelEventoDto eventoEmAndamento = cacaNiquel.montarResultado(pupEscolhido, somCacaNiquel, sprSorteado);
                produtorDeEvento.produziuEvento(eventoEmAndamento);

                clicado++;
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                yield return null;
            }
        }
        somCacaNiquel.pararSomSlotsMovimento();
        yield return new WaitForSeconds(0.1f);

        Sprite[] resultadosSprs = grupoDisplays.getResultadosCacaNiquel();                
        CacaNiquelEventoDto eventoFim = cacaNiquel.montarResultados(pupEscolhido, resultadosSprs);        
        produtorDeEvento.produziuEvento(eventoFim);       
    }       

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
