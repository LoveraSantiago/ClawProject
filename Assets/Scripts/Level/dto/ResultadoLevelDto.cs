public class ResultadoLevelDto
{
    public MapaEntidade mapaEntidade { get; private set;  }
    public string tempoPartida { get; private set; }
    public ResultadoColetaveisDto resultadosColetaveis;
    public int subidasDaGarra { get; private set; }

    public ResultadoLevelDto(string tempoPartida, int subidasDaGarra)
    {
        this.tempoPartida = tempoPartida;
        this.subidasDaGarra = subidasDaGarra;
    }

    public ResultadoLevelDto addResultadoColetaveis(ResultadoColetaveisDto resultadosColetaveis)
    {
        this.resultadosColetaveis = resultadosColetaveis;
        return this;
    }

    public ResultadoLevelDto addMapaEntidade(MapaEntidade mapaEntidade)
    {
        this.mapaEntidade = mapaEntidade;
        return this;
    }
}
