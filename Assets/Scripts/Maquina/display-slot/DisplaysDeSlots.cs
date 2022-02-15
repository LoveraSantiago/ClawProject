public class DisplaysDeSlots : AcaoColetadoFim.ProdutorEvento,
                               AcaoCacaNiquel.ProdutorEvento
{
    private GrupoDisplays grupoDisplays;
    public DisplaysDeColetados displayDeColetados { get; private set; }
    private DisplayCacaNiquel displayCacaNiquel;

    public DisplaysDeSlots(DisplaysSlotsDto displaysSlotsDto)
    {
        grupoDisplays      = new GrupoDisplays(displaysSlotsDto, displaysSlotsDto.SingleDisplaySlotDto);
        displayDeColetados = new DisplaysDeColetados(displaysSlotsDto, grupoDisplays);        
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido, DisplaysSlotsDto displaysSlotsDto)
    {        
        grupoDisplays.colorirDisplays(levelEscolhido.getDicionarioDeCores());

        if (LevelUtils.isCacaNiquelLevel(levelEscolhido))
        {
            displayCacaNiquel = new DisplayCacaNiquel();
            displayCacaNiquel.configuradoPeloLevel(levelEscolhido, displaysSlotsDto.CacaNiquelDto);
        }
    }

    public void iniciar(InputGame inputGame)
    {
        if (isDisplayCacaNiquelAtivado())
        {
            displayCacaNiquel.iniciar(grupoDisplays, inputGame);
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
        return displayCacaNiquel != null;
    }

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoColetadoFim.ProdutorEvento)displayDeColetados).getProdutorDeEvento();
    }

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return isDisplayCacaNiquelAtivado() ? ((AcaoCacaNiquel.ProdutorEvento)displayCacaNiquel).getProdutorDeEvento() : null;
    }
}
