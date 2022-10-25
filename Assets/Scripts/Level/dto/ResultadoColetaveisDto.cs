public class ResultadoColetaveisDto 
{
    public int score { get; private set; }    
    public int totalGaiolasQuebradas { get; private set; }
    public ColetaveisDescartadosDto coletaveisDescartados { get; private set; }

    public ResultadoColetaveisDto addResultados(int score)
    {
        this.score = score;        
        return this;
    }

    public ResultadoColetaveisDto addDescartados(ColetaveisDescartadosDto coletaveisDescartados)
    {
        this.coletaveisDescartados = coletaveisDescartados;
        return this;
    }

    public ResultadoColetaveisDto addTotalGaiolasQuebradas(int totalGaiolasQuebradas)
    {
        this.totalGaiolasQuebradas = totalGaiolasQuebradas;
        return this;
    }
}
