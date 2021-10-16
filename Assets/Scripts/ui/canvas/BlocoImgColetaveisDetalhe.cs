using UnityEngine;

public class BlocoImgColetaveisDetalhe : AcaoBlocoImgColetavelAtual.ConsumidorEvento
{
    private BlocoImgDetalheColetavelDto blocoImgDto;

    public BlocoImgColetaveisDetalhe(
        BlocoImgDetalheColetavelDto blocoImgDto, Material materialGrayScale)
    {
        this.blocoImgDto = blocoImgDto;        
        this.blocoImgDto.ImgDetalhe.material = new Material(materialGrayScale);
    }

    void AcaoBlocoImgColetavelAtual.ConsumidorEvento.consumirEvento(UiColetavelInfo evento)
    {
        blocoImgDto.LblName.text = evento.coletavelEntidade.nome;
        blocoImgDto.ImgDetalhe.sprite = evento.sprite;
        blocoImgDto.ImgDetalhe.material.SetTexture("main_text", evento.sprite.texture);
    }
}
