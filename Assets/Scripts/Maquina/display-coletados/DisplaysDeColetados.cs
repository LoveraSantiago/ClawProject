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

    public void mostrarColetadoNoDisplay(InformacoesColetadoDto evento)
    {
        modoColetados.mostrarColetadoNoDisplay(evento);
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

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        mostrarColetadoNoDisplay(evento);
    }

    ProdutorDeEvento<CacaNiquelEventoDto> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return isDisplayCacaNiquelAtivado() ? ((AcaoCacaNiquel.ProdutorEvento)modoCacaNiquel).getProdutorDeEvento() : null;
    }

}
