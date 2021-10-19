public class AllLabelsPup : AcaoBlocoImgPUpAtual.ConsumidorEvento
{
    private AllLabelsPupDto labelsDto;

    public AllLabelsPup(AllLabelsPupDto labelsDto)
    {
        this.labelsDto = labelsDto;
    }

    void AcaoBlocoImgPUpAtual.ConsumidorEvento.consumirEvento(PowerUpEntidade evento)
    {
        labelsDto.LblPup.text        = evento.nome;
        labelsDto.LblTipo.text       = evento.familia;
        labelsDto.LblDescCurta.text  = evento.descCurta;
        labelsDto.LblExplicacao.text = evento.descDetalhada;
        labelsDto.LblPreco.text      = evento.preco;
        labelsDto.LblQtd.text        = "QTD: " + PlayerPrefsPup.recuperarQtdPup(evento.nome);
    }
}
