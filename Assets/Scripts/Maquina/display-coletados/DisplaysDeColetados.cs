public class DisplaysDeColetados : AcaoColetadoFim.ProdutorEvento,
                               AcaoCacaNiquel.ProdutorEvento
{
    private GrupoDisplays grupoDisplays;
    public ModoColetados modoColetados { get; private set; }
    private ModoCacaNiquel modoCacaNiquel;

    public DisplaysDeColetados(DisplaysColetadosDto displaysSlotsDto)
    {
        grupoDisplays = new GrupoDisplays(displaysSlotsDto);
        modoColetados = new ModoColetados(grupoDisplays);        
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

    public void mostrarColetadoNoDisplay(InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris)
    {
        modoColetados.mostrarColetadoNoDisplay(evento, arcoIris);
    }

    public void processarPowerUp(PowerUpInfo evento)
    {
        InteracaoPowerUpComComponente interacaoPupCComponentes = evento.interacaoComComponentes;
        if (InteracaoComponentesUtils.isInteracaoComDisplayColetado(interacaoPupCComponentes))            
        {
            PowerUpInteracaoComDisplayColetado interacaoDisplayColetado = InteracaoComponentesUtils.getAsInteracaoComDisplayColetado(interacaoPupCComponentes);
            modoColetados.processarPowerUp(evento.tipo, interacaoDisplayColetado);
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

    ProdutorDeEvento<ColetadoFimDto> AcaoColetadoFim.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoColetadoFim.ProdutorEvento)modoColetados).getProdutorDeEvento();
    }

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return isDisplayCacaNiquelAtivado() ? ((AcaoCacaNiquel.ProdutorEvento)modoCacaNiquel).getProdutorDeEvento() : null;
    }
}
