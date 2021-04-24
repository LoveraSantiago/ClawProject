using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : AbstractLevel
{
    public override string getMsgObjetivoLevel()
    {
        return "Colete todos os itens.";
    }

    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,] {
            { 0, 11, 11, 11, 11, 11, 0 },
            { 0, 12, 12, 12, 12, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 } };
    }

    public override bool devolverParaBoard()
    {
        return false;
    }
}
