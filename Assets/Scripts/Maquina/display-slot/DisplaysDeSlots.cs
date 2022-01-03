public class DisplaysDeSlots : AcaoColetadoFim.ProdutorEvento,
                               AcaoCacaNiquel.ProdutorEvento
{
    private GrupoDisplays grupoDisplays;

    public DisplaysDeColetados displayDeColetados { get; private set; }
    private DisplayCacaNiquel displayCacaNiquel;

    public DisplaysDeSlots(DisplaysSlotsDto displaysSlotsDto, InputGame inputGame)
    {
        grupoDisplays = new GrupoDisplays(displaysSlotsDto, displaysSlotsDto.SingleDisplaySlotDto);

        displayDeColetados = new DisplaysDeColetados(displaysSlotsDto, grupoDisplays);
        displayCacaNiquel  = new DisplayCacaNiquel(inputGame);
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {        
        grupoDisplays.colorirDisplays(levelEscolhido.getDicionarioDeCores());
        displayCacaNiquel.configuradoPeloLevel(levelEscolhido.getTipoGameDesc());
    }

    public void iniciar()
    {
        displayCacaNiquel.iniciar(grupoDisplays);
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
        if (evento.interacaoDisplayColetado != null)
        {
            displayDeColetados.processarPowerUp(evento.tipo, evento.interacaoDisplayColetado);
        }
    }

    public void processarFimPowerUp(BotoesPowerUp botoesPup)
    {
        displayDeColetados.processarFimPowerUp(botoesPup);
    }

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoColetadoFim.ProdutorEvento)displayDeColetados).getProdutorDeEvento();
    }

    ProdutorDeEvento<CacaNiquelResultadoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoCacaNiquel.ProdutorEvento)displayCacaNiquel).getProdutorDeEvento();
    }
}
