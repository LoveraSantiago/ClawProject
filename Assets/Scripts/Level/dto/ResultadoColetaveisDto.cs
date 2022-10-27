public class ResultadoColetaveisDto 
{
    public int score { get; private set; }    
    public int totalGaiolasQuebradas { get; private set; }
    public int totalColetaveisDescartados { get { return coletaveisDescartados.listaDeTrincaDeDescartados.Count * 3; } }    

    public ColetaveisDescartadosDto coletaveisDescartados { get; private set; }
    public ColetaveisDescartadosDto coletaveisDevolvidos { get; private set; }

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

    public ResultadoColetaveisDto addDevolvidos(ColetaveisDescartadosDto coletaveisDevolvidos)
    {
        this.coletaveisDevolvidos = coletaveisDevolvidos;
        return this;
    }

    public ResultadoColetaveisDto addTotalGaiolasQuebradas(int totalGaiolasQuebradas)
    {
        this.totalGaiolasQuebradas = totalGaiolasQuebradas;
        return this;
    }
}
