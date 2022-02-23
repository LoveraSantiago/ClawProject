using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : AbstractLevelObstaculos
{
    public override string getLevelName()
    {
        return "Nível 5";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Colete com obstaculos";
    }

    public override int[,] getArrayDeColetaveis()
    {
        throw new System.NotImplementedException();
    }

    public override int[,] getArrayDeObstaculos()
    {
        throw new System.NotImplementedException();
    }

    public override ColetavelEntidade.FAMILIA getFamiliaColetavel()
    {
        return ColetavelEntidade.FAMILIA.FRUTAS;
    }

    public override bool devolverParaBoard()
    {
        return false;
    }

    public override TipoContagemTempoDto getTempoContagem()
    {
        return new TipoContagemTempoDto(ContadorTimer.Contagem.NORMAL, TIMER_ZERO);
    }

    public override Dictionary<string, string> getDicionarioDeCores()
    {
        throw new System.NotImplementedException();
    }
}
