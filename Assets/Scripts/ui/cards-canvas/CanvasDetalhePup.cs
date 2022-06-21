public class CanvasDetalhePup : AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    private CanvasDetalheCardPupDto canvasDetalheDto;

    public CanvasDetalhePup(CanvasDetalheCardPupDto canvasDetalheDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
    }

    void AcaoCardPowerUpSelecionado.ConsumidorEvento.consumirEvento(CardPupSelecionadoDto evento)
    {
        PowerUpEntidade pupEntidade = evento.powerUpEntidade;
        MaterialTipoPowerUpDto materialDetalhe = pupEntidade.getMaterial();
        canvasDetalheDto.ImgBackground.color   = materialDetalhe.CorPrincipal;
        canvasDetalheDto.ImgCirculo.color      = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgExplicacao.color   = materialDetalhe.CorEscura;
        canvasDetalheDto.LblPreco.text         = pupEntidade.preco;
        canvasDetalheDto.LblExplicacao.text    = pupEntidade.descDetalhada;
        canvasDetalheDto.LblQtd.text           = pupEntidade.getQtd().ToString();
        canvasDetalheDto.LblNome.text          = pupEntidade.nome;
        canvasDetalheDto.LblTipo.text          = pupEntidade.familia;
    }
}
