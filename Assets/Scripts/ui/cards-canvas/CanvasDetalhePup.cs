using UnityEngine;

public class CanvasDetalhePup : AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    public bool isAberto { get; private set; }
    private CanvasDetalheCardPupDto canvasDetalheDto;

    public CanvasDetalhePup(CanvasDetalheCardPupDto canvasDetalheDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
        isAberto = false;
    }

    public void dismiss()
    {
        isAberto = false;
    }

    void AcaoCardPowerUpSelecionado.ConsumidorEvento.consumirEvento(CardPupSelecionadoDto evento)
    {
        isAberto = true;        
        PowerUpEntidade pupEntidade = evento.powerUpEntidade;
        MaterialTipoPowerUpDto materialDetalhe = pupEntidade.getMaterial();
        canvasDetalheDto.ImgBackground.color   = materialDetalhe.CorPrincipal;
        canvasDetalheDto.ImgCirculo.color      = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgExplicacao.color   = materialDetalhe.CorEscura;
        canvasDetalheDto.ImgPup.sprite         = pupEntidade.sprPersonagemPup;
        canvasDetalheDto.ImgBtn.sprite         = pupEntidade.sprIconPowerUp;
        canvasDetalheDto.LblPreco.text         = pupEntidade.preco;
        canvasDetalheDto.LblExplicacao.text    = pupEntidade.descDetalhada;
        canvasDetalheDto.LblQtd.text           = pupEntidade.getQtd().ToString();
        canvasDetalheDto.LblNome.text          = pupEntidade.nome;
        canvasDetalheDto.LblTipo.text          = pupEntidade.familia;
    }
}
