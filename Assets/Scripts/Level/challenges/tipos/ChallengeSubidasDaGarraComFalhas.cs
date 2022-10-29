using UnityEngine;

public class ChallengeSubidasDaGarraComFalhas : Challenge
{
    private int falhas;

    public ChallengeSubidasDaGarraComFalhas(int falhas)
    {
        this.falhas = falhas;
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Falhe " + falhas.ToString() + " vezes ao coletar");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {

        int diferenca = resultadoLevelsDto.subidasDaGarra - resultadoLevelsDto.resultadosColetaveis.totalColetaveisDescartados;
        //Debug.Log(" Subidas " + resultadoLevelsDto.subidasDaGarra + " coletados " + resultadoLevelsDto.totalColetaveis
        //    + " diferenca " + diferenca + " falhas " + falhas);
        return diferenca >= falhas;
    }
}
