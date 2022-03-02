using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMontadorObstaculos : BoardMontadorNormal
{
    private bool[,] obstaculos;

    public override void configuradoPeloLevel(AbstractLevel level)
    {
        base.configuradoPeloLevel(level);
        obstaculos = LevelUtils.getArrayDeObstaculos(level);
    }

    protected override PosicaoItensDoBoardDto getPosYITem(BoardDto boardDto)
    {
        return boardDto.PosicoesYObstaculos;
    }

    protected override PosicaoItensDoBoardDto getPosicaoItem(BoardDto boardDto, int indice)
    {
        return boardDto.PosicoesXPares;        
    }

    protected override void onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {
        base.onColetavelCriado(posX, posY, coletavel);
        bool temGaiola = obstaculos[posY, posX];
        if (temGaiola)
        {
            Gaiola gaiola = new Gaiola();
            gaiola.colocarNaPosicao(coletavel.getPosicao());
        }
    }
}
