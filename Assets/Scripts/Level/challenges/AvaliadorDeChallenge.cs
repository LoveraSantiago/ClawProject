public class AvaliadorDeChallenge 
{
    public int challengeUnificado { get; private set; }
    public bool[] resultadoLevel { get; private set; }
    public bool evolucao { get; private set; }

    public AvaliadorDeChallenge(ResultadoLevelDto resultadoLevels, Challenge[] challenges, int challengeAtual)
    {
        int tamanhoArray = 3;

        resultadoLevel = new bool[tamanhoArray];
        bool[] resultadosUnificados = new bool[tamanhoArray];
        bool[] resultadosAtuais = ChallengesUtils.toArray(challengeAtual);

        for(int contador = 0; contador < resultadosUnificados.Length; contador++)
        {
            resultadoLevel[contador] = challenges[contador].resultado(resultadoLevels);
            resultadosUnificados[contador] = resultadoLevel[contador] || resultadosAtuais[contador];

            if(!evolucao && !resultadosAtuais[contador] && resultadoLevel[contador])
            {
                evolucao = true;
            }
        }

        challengeUnificado = ChallengesUtils.toInteiro(resultadosUnificados);
    }
}
