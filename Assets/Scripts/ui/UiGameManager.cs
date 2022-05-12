public class UiGameManager : AcaoTempoEsgotado.ConsumidorEvento,
                             AcaoBoardElevadoFim.ConsumidorEvento,                             
                             AcaoCacaNiquel.ConsumidorEvento,                             
                             AcaoDesligarMaquina.ConsumidorEvento
{
    public ModalResultadosManager modalResultados { get; private set; }
    public ModalSair modalSair { get; private set; }

    public UiGameManager(UIGameDto uiDto)
    {
        modalResultados   = new ModalResultadosManager(uiDto.ModalPontosDto);        
        modalSair         = new ModalSair(uiDto.ModalSairDto);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        modalResultados.configurarLevel(levelEscolhido.getLevelName());        
        modalSair.configuradoPeloLevel(levelEscolhido);
    }    

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotadoDto evento)
    {
        ((AcaoTempoEsgotado.ConsumidorEvento)modalResultados).consumirEvento(evento);
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
    {
        ((AcaoBoardElevadoFim.ConsumidorEvento)modalResultados).consumirEvento(evento);
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelEventoDto evento)
    {
        ((AcaoCacaNiquel.ConsumidorEvento)modalResultados).consumirEvento(evento);
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquinaDto evento)
    {
        ((AcaoDesligarMaquina.ConsumidorEvento)modalSair).consumirEvento(evento);
    }
}
