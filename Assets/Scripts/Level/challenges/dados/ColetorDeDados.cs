public class ColetorDeDados 
{    
    private Fornecedor<string> provedorDadosTempo;
    private Fornecedor<int> provedorDadosScore;
    private Fornecedor<int> provedorSubidasDaGarra;

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

    public ColetorDeDados addProvedorSubidasDaGarra(Fornecedor<int> provedorSubidasDaGarra)
    {
        this.provedorSubidasDaGarra = provedorSubidasDaGarra;
        return this;
    }

    public ResultadoLevelsDto coletar()
    {
        string tempoPartida = provedorDadosTempo.fornecer();
        int score = provedorDadosScore.fornecer();
        int subidasDaGarra = provedorSubidasDaGarra.fornecer();

        ResultadoLevelsDto resultadoLevelsDto = new ResultadoLevelsDto(tempoPartida, score, subidasDaGarra);
        return resultadoLevelsDto;
    }
}
