using System;

public class PopuladorCanvasDetalhePup 
{
    public void popular(CanvasDetalheCardPupDto canvasDetalheDto, PowerUpEntidade pupEntidade)
    {
        MaterialTipoPowerUpDto materialDetalhe = pupEntidade.getMaterial();
        canvasDetalheDto.ImgBackground.color = materialDetalhe.CorPrincipal;
        canvasDetalheDto.ImgCirculo.color = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgExplicacao.color = materialDetalhe.CorEscura;
        canvasDetalheDto.ImgPup.sprite = pupEntidade.sprPersonagemPup;
        canvasDetalheDto.ImgCorBtnPrin[0].color = materialDetalhe.CorVariacao1;
        canvasDetalheDto.ImgCorBtnPrin[1].color = materialDetalhe.CorVariacao2;
        canvasDetalheDto.ImgCorBtnPrin[2].color = materialDetalhe.CorVariacao3;
        canvasDetalheDto.ImgCorBtnSec[0].color = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgCorBtnSec[1].color = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgCorBtnSec[2].color = materialDetalhe.CorCirculo;
        canvasDetalheDto.ImgBtns[0].color = materialDetalhe.CorEscura;
        canvasDetalheDto.ImgBtns[1].color = materialDetalhe.CorEscura;
        canvasDetalheDto.ImgBtns[2].color = materialDetalhe.CorEscura;
        canvasDetalheDto.LblPreco.text = pupEntidade.preco;
        canvasDetalheDto.LblExplicacao.text = pupEntidade.descCurta + Environment.NewLine + pupEntidade.descDetalhada;
        canvasDetalheDto.LblQtd.text = pupEntidade.getQtd().ToString();
        canvasDetalheDto.LblNome.text = pupEntidade.nome;
        canvasDetalheDto.LblTipo.text = pupEntidade.familia;
    }
}
