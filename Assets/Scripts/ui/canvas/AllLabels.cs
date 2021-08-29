public class AllLabels : AcaoBlocoImgPUpAtual.ConsumidorEvento
{
    private AllLabelsDto labelsDto;

    public AllLabels(AllLabelsDto labelsDto)
    {
        this.labelsDto = labelsDto;
    }

    void AcaoBlocoImgPUpAtual.ConsumidorEvento.consumirEvento(PowerUpEntidade evento)
    {
        labelsDto.LblPup.text = evento.nome;
        labelsDto.LblDescCurta.text = evento.descCurta;
        labelsDto.LblExplicacao.text = evento.descDetalhada;
    }
}
