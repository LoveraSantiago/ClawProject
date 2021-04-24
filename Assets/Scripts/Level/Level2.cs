using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : AbstractLevel
{
    public override string getMsgObjetivoLevel()
    {
        return "Faça uma trinca de espadas";
    }

    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            { 10, 10, 10, 11, 11, 11, 12 },
            { 14, 14, 14, 13, 13, 13, 0 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 } };
    }

    public override bool devolverParaBoard()
    {
        return true;
    }
}
