public class DisplaysDeSlots : AcaoColetadoFim.ProdutorEvento
{
    private GrupoDisplays grupoDisplays;

    private DisplaysDeColetados displayDeColetados;
    private DisplayCacaNiquel displayCacaNiquel;

    public DisplaysDeSlots(DisplaysSlotsDto displaysSlotsDto)
    {
        grupoDisplays = new GrupoDisplays(displaysSlotsDto.SingleDisplaySlotDto, displaysSlotsDto.MaterialGlowDisplay);

        displayDeColetados = new DisplaysDeColetados(displaysSlotsDto, grupoDisplays);
        displayCacaNiquel  = new DisplayCacaNiquel();
    }

    public void configuradoPeloLevel(AbstractLevel levelEscolhido)
    {
        displayDeColetados.configuradoPeloLevel(levelEscolhido.getDicionarioDeCores());
        displayCacaNiquel.configuradoPeloLevel(levelEscolhido.getTipoGame());
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
}
