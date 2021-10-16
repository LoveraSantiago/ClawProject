using System.Collections;
using System.Collections.Generic;
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
        this.blocoImgDto.LblName.text = evento.coletavelEntidade.nome;
        this.blocoImgDto.ImgDetalhe.sprite = evento.sprite;
    }
}
