public class UiGameManager : AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                             AcaoColetado.ConsumidorEvento,
                             AcaoTempoEsgotado.ConsumidorEvento,
                             AcaoBoardElevadoFim.ConsumidorEvento,
                             AcaoBotaoPUpVazio.ConsumidorEvento,
                             AcaoCacaNiquel.ConsumidorEvento,
                             AcaoPUpAcionado.ConsumidorEvento
{
    private ModalPontos modalPontos;
    private ScrollManager scrollManager;

    public UiGameManager(UIGameDto uiDto)
    {
        modalPontos = new ModalPontos(uiDto.ModalPontosDto);
        scrollManager = new ScrollManager(uiDto.PrefabBottomBar);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        modalPontos.configurarLevel(levelEscolhido.getLevelName());
        scrollManager.configuradoPeloLevel(levelEscolhido);
    }

    public void start()
    {
        scrollManager.start();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        ((AcaoColetado.ConsumidorEvento)modalPontos).consumirEvento(evento);
    }

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        ((AcaoTempoEsgotado.ConsumidorEvento)modalPontos).consumirEvento(evento);
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(BoardAcaoFim evento)
    {
        ((AcaoBoardElevadoFim.ConsumidorEvento)modalPontos).consumirEvento(evento);
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {       
        ((AcaoBotaoPUpVazio.ConsumidorEvento)scrollManager).consumirEvento(evento);       
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelResult evento)
    {
        ((AcaoCacaNiquel.ConsumidorEvento)modalPontos).consumirEvento(evento);
    }

    void AcaoPUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        ((AcaoPUpAcionado.ConsumidorEvento)scrollManager).consumirEvento(evento);
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento)scrollManager).getProdutorDeEvento();
    }
}
