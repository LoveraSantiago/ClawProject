public class ResultadoColetaveisDto 
{
    public int score { get; private set; }
    public int totalColetaveis { get; private set; }
    public ColetaveisDescartadosDto coletaveisDescartados { get; private set; }

    public ResultadoColetaveisDto addResultados(int score, int totalColetaveis)
    {
        this.score = score;
        this.totalColetaveis = totalColetaveis;
        return this;
    }

    public ResultadoColetaveisDto addDescartados(ColetaveisDescartadosDto coletaveisDescartados)
    {
        this.coletaveisDescartados = coletaveisDescartados;
        return this;
    }
}
