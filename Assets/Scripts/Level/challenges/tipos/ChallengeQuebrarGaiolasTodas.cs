public class ChallengeQuebrarGaiolasTodas : Challenge
{
    private int totalGaiolas;

    public ChallengeQuebrarGaiolasTodas(AbstractLevelObstaculos abstractLevelObstaculo)
    {
        totalGaiolas = getQtdGaiolas(abstractLevelObstaculo);
    }

    public ChallengeLabel getLabelChallenge(MapaEntidade mapaEntidade)
    {
        return new ChallengeLabel("Quebre todas as gaiolas do level");
    }

    public bool resultado(ResultadoLevelDto resultadoLevelsDto)
    {
        return totalGaiolas == resultadoLevelsDto.resultadosColetaveis.totalGaiolasQuebradas;
    }

    protected int getQtdGaiolas(AbstractLevelObstaculos abstractLevelObstaculo)
    {
        bool[,] obstaculos = abstractLevelObstaculo.getArrayDeObstaculos();

        int contadorGaiolas = 0;
        for (int contadorX = 0; contadorX < obstaculos.Length; contadorX++)
        {
            for (int contadorY = 0; contadorY < obstaculos.GetLength(contadorX); contadorY++)
            {
                if (obstaculos[contadorX, contadorY])
                {
                    contadorGaiolas++;
                }
            }
        }
        return contadorGaiolas;
    }
}
