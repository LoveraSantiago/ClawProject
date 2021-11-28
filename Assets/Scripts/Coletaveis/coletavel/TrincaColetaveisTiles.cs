using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrincaColetaveisTiles 
{
    private ColetavelTile[] arrayColetados;

    public TrincaColetaveisTiles(ColetavelTile[] arrayColetados)
    {
        this.arrayColetados = arrayColetados;
    }

    public bool isCombinacaoValida()
    {
        return arrayColetados[0].hasEqualsSprite(arrayColetados[1]) &&
               arrayColetados[0].hasEqualsSprite(arrayColetados[2]);
    }

    public int getPrimeiroIndiceVazio()
    {
        if (arrayColetados[0] == null) return 0;
        if (arrayColetados[1] == null) return 1;
        return 2;
    }

    public bool isTodasPosicoesOcupadas()
    {
        return arrayColetados[0] != null && arrayColetados[1] != null && arrayColetados[2] != null;
    }

    public ColetavelTile[] resetarColetados()
    {
        arrayColetados[0] = null;
        arrayColetados[1] = null;
        arrayColetados[2] = null;
        return arrayColetados;
    }
}
