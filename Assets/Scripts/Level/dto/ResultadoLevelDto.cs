public class ResultadoLevelDto
{
    public string tempoPartida { get; private set; }
    public ResultadoColetaveisDto resultadosColetaveis;
    public int subidasDaGarra { get; private set; }

    public ResultadoLevelDto(string tempoPartida, ResultadoColetaveisDto resultadosColetaveis, int subidasDaGarra)
    {
        this.tempoPartida = tempoPartida;
        this.resultadosColetaveis = resultadosColetaveis;
        this.subidasDaGarra = subidasDaGarra;
    }
}
