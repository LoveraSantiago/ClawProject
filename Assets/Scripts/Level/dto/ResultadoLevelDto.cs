public class ResultadoLevelDto
{
    public string tempoPartida { get; private set; }
    public int score { get; private set; }
    public int subidasDaGarra { get; private set; }

    public ResultadoLevelDto(string tempoPartida, int score, int subidasDaGarra)
    {
        this.tempoPartida = tempoPartida;
        this.score = score;
        this.subidasDaGarra = subidasDaGarra;
    }
}
