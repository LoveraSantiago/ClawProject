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
            blocoImgDto.BtnGanharColetavel.enabled = false;
            blocoImgDto.LblBtnGanharColetavel.text = "Voce já possui esse coletavel";
            
        }
        else if (evento.isNaoColetado)
        {
            Material matGrayScale = new Material(Utils.materialGrayScale);
            matGrayScale.SetTexture("main_text", evento.sprite.texture);
            blocoImgDto.ImgDetalhe.material = matGrayScale;
            blocoImgDto.ImgDetalhe.color = Color.white;
            blocoImgDto.BtnGanharColetavel.enabled = true;
            blocoImgDto.LblBtnGanharColetavel.text = "TENTAR GANHAR COLETAVEL";
        }
        else
        {
            blocoImgDto.ImgDetalhe.material = null;
            blocoImgDto.ImgDetalhe.color = Color.black;
            blocoImgDto.BtnGanharColetavel.enabled = false;
            blocoImgDto.LblBtnGanharColetavel.text = "Libere a fase XXX antes";
        }
    }
}
