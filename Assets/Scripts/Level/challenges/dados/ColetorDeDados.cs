public class ColetorDeDados 
{    
    private Fornecedor<string> provedorDadosTempo;
    private Fornecedor<int> provedorDadosScore;

    public ColetorDeDados addProvedorDadosTempo(Fornecedor<string> provedorDadosTempo)
    {
        this.provedorDadosTempo = provedorDadosTempo;
        return this;
    }

    public ColetorDeDados addProvedorDadosScore(Fornecedor<int> provedorDadosScore)
    {
        this.provedorDadosScore = provedorDadosScore;
        return this;
    }

    public ResultadoLevelsDto coletar()
    {
        string tempoPartida = provedorDadosTempo.fornecer();
        int score = provedorDadosScore.fornecer();

        ResultadoLevelsDto resultadoLevelsDto = new ResultadoLevelsDto(tempoPartida, score);
        return resultadoLevelsDto;
    }
}
