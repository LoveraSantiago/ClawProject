public class ResultadoDesligarMaquinaDto 
{
    public bool resultadoSair { get; private set; }

    public ResultadoDesligarMaquinaDto(bool resultadoSair)
    {
        this.resultadoSair = resultadoSair;
    }
}
