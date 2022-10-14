public class ResultadoColetaveisDto 
{
    public int score { get; private set; }
    public int totalColetaveis { get; private set; }

    public ResultadoColetaveisDto(int score, int totalColetaveis)
    {
        this.score = score;
        this.totalColetaveis = totalColetaveis;
    }
}
