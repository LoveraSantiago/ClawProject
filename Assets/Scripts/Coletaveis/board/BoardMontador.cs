using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardMontador 
{
    protected static ColetavelEntidade.FAMILIA familia;

    public static void configurar(ColetavelEntidade.FAMILIA familiaArg)
    {
        familia = familiaArg;
    }    

    protected float[] getEixoX(BoardDto boardDto, int indice)
    {
        if (indice % 2 == 0)
        {
            return boardDto.PosicoesEixoXPar;
        }
        else
        {
            return boardDto.PosicoesEixoXImpar;
        }
    }
}
