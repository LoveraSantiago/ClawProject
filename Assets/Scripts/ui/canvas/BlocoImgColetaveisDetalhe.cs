using UnityEngine;

public class BlocoImgColetaveisDetalhe : AcaoBlocoImgColetavelAtual.ConsumidorEvento
{
    private BlocoImgDetalheColetavelDto blocoImgDto;    

    public BlocoImgColetaveisDetalhe(BlocoImgDetalheColetavelDto blocoImgDto)
    {
        this.blocoImgDto = blocoImgDto;        
    }

    void AcaoBlocoImgColetavelAtual.ConsumidorEvento.consumirEvento(UiColetavelInfo evento)
    {
        blocoImgDto.LblName.text = evento.coletavelEntidade.nome;
        blocoImgDto.ImgDetalhe.sprite = evento.sprite;

        if (evento.isColetado)
        {
            blocoImgDto.ImgDetalhe.material = null;
            blocoImgDto.ImgDetalhe.color = Color.white;
        }
        else if (evento.isNaoColetado)
        {
            Material matGrayScale = new Material(Utils.materialGrayScale);
            matGrayScale.SetTexture("main_text", evento.sprite.texture);
            blocoImgDto.ImgDetalhe.material = matGrayScale;
            blocoImgDto.ImgDetalhe.color = Color.white;
        }
        else
        {
            blocoImgDto.ImgDetalhe.material = null;
            blocoImgDto.ImgDetalhe.color = Color.black;
        }
    }
}
