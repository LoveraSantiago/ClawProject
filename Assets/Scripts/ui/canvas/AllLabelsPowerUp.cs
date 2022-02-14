public class AllLabelsPowerUp : AcaoBlocoImgPowerUpAtual.ConsumidorEvento
{
    private AllLabelsPupDto labelsDto;

    public AllLabelsPowerUp(AllLabelsPupDto labelsDto)
    {
        this.labelsDto = labelsDto;
    }

    void AcaoBlocoImgPowerUpAtual.ConsumidorEvento.consumirEvento(PowerUpEntidade evento)
    {
        labelsDto.LblPup.text        = evento.nome;
        labelsDto.LblTipo.text       = evento.familia;
        labelsDto.LblDescCurta.text  = evento.descCurta;
        labelsDto.LblExplicacao.text = evento.descDetalhada;
        labelsDto.LblPreco.text      = evento.preco;
        labelsDto.LblQtd.text        = PlayerPrefsPup.recuperarQtdPup(evento.nome) + "";
    }
}
