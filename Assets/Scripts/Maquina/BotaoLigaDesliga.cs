using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoLigaDesliga 
{
    private BotoesLigaDesligaDto btnsLigaDesligaDto;

    public BotaoLigaDesliga(BotoesLigaDesligaDto btnsLigaDesligaDto)
    {
        this.btnsLigaDesligaDto = btnsLigaDesligaDto;
    }

    public void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaInferior())
        {
            Vector2 posicaoTap = inputGame.getPosicaoTap();
            if ()
            {

            }
        }
    }
}
