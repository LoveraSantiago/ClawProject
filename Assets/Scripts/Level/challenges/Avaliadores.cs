using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avaliadores 
{
    private Challenge[] challenges;

    public Avaliadores(Challenge[] challenges)
    {
        this.challenges = challenges;
    }

    public int avaliar()
    {
        bool[] resultados = new bool[3];
        for(int contador = 0; contador < resultados.Length; contador++)
        {
            resultados[contador] = challenges[contador].resultado();
        }
        return 0;
    }
}
