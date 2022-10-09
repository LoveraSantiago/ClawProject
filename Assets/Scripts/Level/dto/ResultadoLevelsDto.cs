public class ResultadoLevelsDto
{
    public string tempoPartida { get; private set; }
    public int score { get; private set; }

    public ResultadoLevelsDto(string tempoPartida, int score)
    {
        this.tempoPartida = tempoPartida;
        this.score = score;
    }
}
