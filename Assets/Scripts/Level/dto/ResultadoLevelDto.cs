public class ResultadoLevelDto
{
    public MapaEntidade mapaEntidade { get; private set;  }

    public int subidasDaGarra { get; private set; }
    public int subidasDoElevador { get; private set; }
    public string tempoPartida { get; private set; }
    public ResultadoColetaveisDto resultadosColetaveis { get; private set; }
    public ResultadoPowerUpDto resultadosPowerUp { get; private set; }

    public ResultadoLevelDto(string tempoPartida, int subidasDaGarra, int subidasElevador)
    {
        this.tempoPartida = tempoPartida;
        this.subidasDaGarra = subidasDaGarra;
        this.subidasDoElevador = subidasDoElevador;
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

    public ResultadoLevelDto addResultadosPowerUp(ResultadoPowerUpDto resultadosPowerUp)
    {
        this.resultadosColetaveis = resultadosColetaveis;
        return this;
    }
}
