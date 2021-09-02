public class DisplaysDeSlots : AcaoColetadoFim.ProdutorEvento,
                               AcaoCacaNiquel.ProdutorEvento
{
    private GrupoDisplays grupoDisplays;

    private DisplaysDeColetados displayDeColetados;
    private DisplayCacaNiquel displayCacaNiquel;

    public DisplaysDeSlots(DisplaysSlotsDto displaysSlotsDto, InputGame inputGame)
    {
        grupoDisplays = new GrupoDisplays(displaysSlotsDto, displaysSlotsDto.SingleDisplaySlotDto, displaysSlotsDto.MaterialGlowDisplay);

        displayDeColetados = new DisplaysDeColetados(displaysSlotsDto, grupoDisplays);
        displayCacaNiquel  = new DisplayCacaNiquel(inputGame);
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {        
        grupoDisplays.colorirDisplays(levelEscolhido.getDicionarioDeCores());
        displayCacaNiquel.configuradoPeloLevel(levelEscolhido.getTipoGame());
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

    public void processarPowerUp(PowerUpInteracaoDisplayColetado interacaoDisplayColetado)
    {
        displayDeColetados.processarPowerUp(interacaoDisplayColetado);
    }

    public void processarFimPowerUp(BotoesPowerUp botoesPup)
    {
        displayDeColetados.processarFimPowerUp(botoesPup);
    }

    ProdutorDeEvento<ColetadoFim> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoColetadoFim.ProdutorEvento)displayDeColetados).getProdutorDeEvento();
    }

    ProdutorDeEvento<Vazio> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoCacaNiquel.ProdutorEvento)displayCacaNiquel).getProdutorDeEvento();
    }
}
