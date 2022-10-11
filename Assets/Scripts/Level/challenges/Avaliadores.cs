public class Avaliadores 
{
    public int challengeUnificado { get; private set; }
    public bool[] resultadoLevel { get; private set; }

    public void avaliar(ResultadoLevelsDto resultadoLevels, Challenge[] challenges, int challengeAtual)
    {
        int tamanhoArray = 3;

        resultadoLevel = new bool[tamanhoArray];
        bool[] resultadosUnificados = new bool[tamanhoArray];
        bool[] resultadosAtuais = ChallengesUtils.toArray(challengeAtual);

        for(int contador = 0; contador < resultadosUnificados.Length; contador++)
        {
            resultadosAtuais[contador] = challenges[contador].resultado();
            resultadosUnificados[contador] = resultadosAtuais[contador] || resultadosAtuais[contador];
        }

        challengeUnificado = ChallengesUtils.toInteiro(resultadosUnificados);
    }
}
