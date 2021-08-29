using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPup : AbstractLevel
{
    public override bool devolverParaBoard()
    {
        return false;
    }

    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1},
            {1, 1, 1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        throw new System.NotImplementedException();
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override string getLevelName()
    {
        return "Treino de Power Up";
    }

    public override GarraManager.MECANICA_GARRA getMecanicaDaGarra()
    {
        return GarraManager.MECANICA_GARRA.ZIG_ZAG;
    }

    public override string getMsgObjetivoLevel()
    {
        return "Treinar Habilidades em Power Up";
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }
}
