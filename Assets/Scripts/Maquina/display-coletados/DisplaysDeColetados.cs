using System.Collections.Generic;

public class DisplaysDeColetados : AcaoCacaNiquel.ProdutorEvento,
                                   AcaoColetado.ConsumidorEvento
{
    private GrupoDisplays grupoDisplays;
    public ModoColetados modoColetados { get; private set; }
    private ModoCacaNiquel modoCacaNiquel;

    public DisplaysDeColetados(DisplaysColetadosDto displaysSlotsDto, ArcoIrisEfeito arcoIrisEfeito, SomMaquina somMaquina)
    {
        grupoDisplays = new GrupoDisplays(displaysSlotsDto, somMaquina);
        modoColetados = new ModoColetados(grupoDisplays, arcoIrisEfeito);        
    }

    public void configuradoPeloLevel(DisplaysColetadosDto displaysSlotsDto, SomCacaNiquel somCacaNiquel)
    {        
        grupoDisplays.colorirDisplays();

        if (LevelUtils.isCacaNiquelLevel())
        {
            modoCacaNiquel = new ModoCacaNiquel();
            modoCacaNiquel.configuradoPeloLevel(displaysSlotsDto.CacaNiquelDto, somCacaNiquel);
        }
        else if (LevelUtils.isTutorialLevel())
        {
            InformacoesColetadoDto[] informacoesColetados = LevelUtils.getInformacoesColetadosDto();
            for(int contador = 0; contador < informacoesColetados.Length; contador++)
            {
                mostrarColetadoNoDisplay(informacoesColetados[contador], contador);
            }
        }
    }

    public void iniciar(InputGame inputGame, SomCacaNiquel somCacaNiquel)
    {
        if (isDisplayCacaNiquelAtivado())
        {
            modoCacaNiquel.iniciar(grupoDisplays, somCacaNiquel, inputGame);
        }
    }  

    public void mostrarColetadoNoDisplay(InformacoesColetadoDto evento)
    {
        modoColetados.mostrarColetadoNoDisplay(evento);
    }
    
    private void mostrarColetadoNoDisplay(InformacoesColetadoDto evento, int indiceDisplay)
    {
        modoColetados.mostrarColetadoNoDisplay(evento, indiceDisplay);
    }

    public void processarPowerUp(PowerUpInfoDto evento)
    {
        InteracaoPowerUpComComponente interacaoPupCComponentes = evento.interacaoPupComComponentes;
        if (InteracaoComponentesUtils.isInteracaoComDisplayColetado(interacaoPupCComponentes))            
        {
            PowerUpInteracaoComDisplayColetado interacaoDisplayColetado = InteracaoComponentesUtils.getAsInteracaoComDisplayColetado(interacaoPupCComponentes);
            modoColetados.processarPowerUp(evento.tipoPupEntidade, interacaoDisplayColetado);
        }
    }

    public void processarFimPowerUp(BotoesPowerUp botoesPup)
    {
        modoColetados.processarFimPowerUp(botoesPup);
    }

    private bool isDisplayCacaNiquelAtivado()
    {
        return modoCacaNiquel != null;
    }   

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        mostrarColetadoNoDisplay(evento);
    }

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return isDisplayCacaNiquelAtivado() ? ((AcaoCacaNiquel.ProdutorEvento)modoCacaNiquel).getProdutorDeEvento() : null;
    }

}
