public class ResultadoDesligarMaquinaDto 
{
    public bool resultadoSair { get; private set; }
    public bool isGameLevel { get; private set; }

    public ResultadoDesligarMaquinaDto(bool resultadoSair)
        :this(resultadoSair, false)
    {
    }

    public ResultadoDesligarMaquinaDto(bool resultadoSair, bool isGameLevel)
    {
        this.resultadoSair = resultadoSair;
        this.isGameLevel = isGameLevel;
    }
}
