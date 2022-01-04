public class DisplaysDeSlots : AcaoColetadoFim.ProdutorEvento,
                               AcaoCacaNiquel.ProdutorEvento
{
    private GrupoDisplays grupoDisplays;

    public DisplaysDeColetados displayDeColetados { get; private set; }
    private DisplayCacaNiquel displayCacaNiquel;

    public DisplaysDeSlots(DisplaysSlotsDto displaysSlotsDto)
    {
        grupoDisplays = new GrupoDisplays(displaysSlotsDto, displaysSlotsDto.SingleDisplaySlotDto);

        displayDeColetados = new DisplaysDeColetados(displaysSlotsDto, grupoDisplays);
        displayCacaNiquel  = new DisplayCacaNiquel();
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido, DisplaysSlotsDto displaysSlotsDto)
    {        
        grupoDisplays.colorirDisplays(levelEscolhido.getDicionarioDeCores());
        displayCacaNiquel.configuradoPeloLevel(levelEscolhido.getTipoGameDesc(), displaysSlotsDto.CacaNiquelDto);
    }

    public void iniciar(InputGame inputGame)
    {
        displayCacaNiquel.iniciar(grupoDisplays, inputGame);
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

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoCacaNiquel.ProdutorEvento)displayCacaNiquel).getProdutorDeEvento();
    }
}
