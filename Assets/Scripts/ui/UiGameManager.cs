public class UiGameManager : AcaoDesligarMaquinaResultado.ProdutorEvento,
                             AcaoColetado.ConsumidorEvento,
                             AcaoTempoEsgotado.ConsumidorEvento,
                             AcaoBoardElevadoFim.ConsumidorEvento,                             
                             AcaoCacaNiquel.ConsumidorEvento,                             
                             AcaoDesligarMaquina.ConsumidorEvento
{
    private ModalResultadosManager modalResultados;
    private ModalSair modalSair;    

    public UiGameManager(UIGameDto uiDto)
    {
        modalResultados   = new ModalResultadosManager(uiDto.ModalPontosDto);        
        modalSair     = new ModalSair(uiDto.ModalSairDto);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        modalResultados.configurarLevel(levelEscolhido.getLevelName());        
        modalSair.configuradoPeloLevel(levelEscolhido);
    }    

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        ((AcaoColetado.ConsumidorEvento)modalResultados).consumirEvento(evento);
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
    
    ProdutorDeEvento<ResultadoDesligarMaquinaDto> AcaoDesligarMaquinaResultado.ProdutorEvento.getProdutorDeEvento()
    {
        return ((AcaoDesligarMaquinaResultado.ProdutorEvento)modalSair).getProdutorDeEvento();
    }
}
