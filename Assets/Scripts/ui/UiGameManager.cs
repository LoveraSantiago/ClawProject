public class UiGameManager : AcaoColetado.ConsumidorEvento,
                             AcaoTempoEsgotado.ConsumidorEvento,
                             AcaoBoardElevadoFim.ConsumidorEvento
{
    private ModalPontos modalPontos;

    public UiGameManager(UIGameDto uiDto)
    {
        modalPontos = new ModalPontos(uiDto.ModalPontosDto);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        modalPontos.configurarLevel(levelEscolhido.getLevelName());
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
}
