using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMontadorObstaculos : BoardMontadorNormal
{
    protected override PosicaoItensDoBoardDto getPosYITem(BoardDto boardDto)
    {
        return boardDto.PosicoesYObstaculos;
    }

    protected override PosicaoItensDoBoardDto getPosicaoItem(BoardDto boardDto, int indice)
    {
        return boardDto.PosicoesXPares;        
    }

    protected override void onColetavelCriado(Coletavel coletavel)
    {
        base.onColetavelCriado(coletavel);        
    }
}
