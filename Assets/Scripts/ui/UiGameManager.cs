public class UiGameManager : AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                             AcaoDesligarMaquinaCancelado.ProdutorEvento,
                             AcaoColetado.ConsumidorEvento,
                             AcaoTempoEsgotado.ConsumidorEvento,
                             AcaoBoardElevadoFim.ConsumidorEvento,
                             AcaoBotaoPowerUpVazio.ConsumidorEvento,
                             AcaoCacaNiquel.ConsumidorEvento,
                             AcaoPowerUpAcionado.ConsumidorEvento,
                             AcaoDesligarMaquina.ConsumidorEvento
{
    private ModalResultadosManager modalResultados;
    private ModalSair modalSair;
    private ScrollManager scrollManager;

    public UiGameManager(UIGameDto uiDto)
    {
        modalResultados   = new ModalResultadosManager(uiDto.ModalPontosDto);
        scrollManager = new ScrollManager(uiDto.PrefabBottomBar);
        modalSair     = new ModalSair(uiDto.ModalSairDto);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        modalResultados.configurarLevel(levelEscolhido.getLevelName());
        scrollManager.configuradoPeloLevel(levelEscolhido);
        modalSair.configuradoPeloLevel(levelEscolhido);
    }

    public void start()
    {
        scrollManager.start();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        ((AcaoColetado.ConsumidorEvento)modalResultados).consumirEvento(evento);
    }

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        ((AcaoTempoEsgotado.ConsumidorEvento)modalResultados).consumirEvento(evento);
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
    {
        ((AcaoBoardElevadoFim.ConsumidorEvento)modalResultados).consumirEvento(evento);
    }

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {       
        ((AcaoBotaoPowerUpVazio.ConsumidorEvento)scrollManager).consumirEvento(evento);       
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelEventoDto evento)
    {
        ((AcaoCacaNiquel.ConsumidorEvento)modalResultados).consumirEvento(evento);
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        ((AcaoPowerUpAcionado.ConsumidorEvento)scrollManager).consumirEvento(evento);
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquinaDto evento)
    {
        ((AcaoDesligarMaquina.ConsumidorEvento)modalSair).consumirEvento(evento);
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollManager).getProdutorDeEvento();
    }

    ProdutorDeEvento<CancelarDesligarMaquina> AcaoDesligarMaquinaCancelado.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoDesligarMaquinaCancelado.ProdutorEvento)modalSair).getProdutorDeEvento();
    }
}
