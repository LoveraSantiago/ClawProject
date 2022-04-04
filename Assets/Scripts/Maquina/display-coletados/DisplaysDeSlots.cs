public class DisplaysDeSlots : AcaoColetadoFim.ProdutorEvento,
                               AcaoCacaNiquel.ProdutorEvento
{
    private GrupoDisplays grupoDisplays;
    public DisplaysDeColetados displayDeColetados { get; private set; }
    private ModoCacaNiquel modoCacaNiquel;

    public DisplaysDeSlots(DisplaysColetadosDto displaysSlotsDto)
    {
        grupoDisplays      = new GrupoDisplays(displaysSlotsDto, displaysSlotsDto.SingleDisplaySlotDto);
        displayDeColetados = new DisplaysDeColetados(displaysSlotsDto, grupoDisplays);        
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido, DisplaysColetadosDto displaysSlotsDto)
    {        
        grupoDisplays.colorirDisplays(levelEscolhido.getDicionarioDeCores());

        if (LevelUtils.isCacaNiquelLevel(levelEscolhido))
        {
            modoCacaNiquel = new ModoCacaNiquel();
            modoCacaNiquel.configuradoPeloLevel(levelEscolhido, displaysSlotsDto.CacaNiquelDto);
        }
    }

    public void iniciar(InputGame inputGame)
    {
        if (isDisplayCacaNiquelAtivado())
        {
            modoCacaNiquel.iniciar(grupoDisplays, inputGame);
        }
    }

    public ArcoIrisConjunto getDisplayColetadoGlow()
    {
        return grupoDisplays;
    }

    public void mostrarColetadoNoDisplay(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        displayDeColetados.mostrarColetadoNoDisplay(evento, arcoIris, executorPosEvento);
    }

    public void processarPowerUp(PowerUpInfo evento)
    {
        InteracaoPowerUpComComponente interacaoPupCComponentes = evento.interacaoComComponentes;
        if (InteracaoComponentesUtils.isInteracaoComDisplayColetado(interacaoPupCComponentes))            
        {
            PowerUpInteracaoComDisplayColetado interacaoDisplayColetado = InteracaoComponentesUtils.getAsInteracaoComDisplayColetado(interacaoPupCComponentes);
            displayDeColetados.processarPowerUp(evento.tipo, interacaoDisplayColetado);
        }
    }

    public void processarFimPowerUp(BotoesPowerUp botoesPup)
    {
        displayDeColetados.processarFimPowerUp(botoesPup);
    }

    private bool isDisplayCacaNiquelAtivado()
    {
        return modoCacaNiquel != null;
    }

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoColetadoFim.ProdutorEvento)displayDeColetados).getProdutorDeEvento();
    }

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return isDisplayCacaNiquelAtivado() ? ((AcaoCacaNiquel.ProdutorEvento)modoCacaNiquel).getProdutorDeEvento() : null;
    }
}
