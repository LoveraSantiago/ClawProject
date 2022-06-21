public class CanvasDetalhePup : AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    private CanvasDetalheCardPupDto canvasDetalheDto;

    public CanvasDetalhePup(CanvasDetalheCardPupDto canvasDetalheDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
    }

    void AcaoCardPowerUpSelecionado.ConsumidorEvento.consumirEvento(CardPupSelecionadoDto evento)
    {
        MaterialTipoPowerUpDto materialDetalhe = evento.powerUpEntidade.getMaterial();
        canvasDetalheDto.ImgBackground.color = materialDetalhe.CorPrincipal;
        canvasDetalheDto.ImgCirculo.color      = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgExplicacao.color   = materialDetalhe.CorEscura;
    }
}
