public class ColetorDeDados 
{    
    private Fornecedor<string> provedorDadosTempo;

    public ColetorDeDados addProvedorDadosTempo(Fornecedor<string> provedorDadosTempo)
    {
        this.provedorDadosTempo = provedorDadosTempo;
        return this;
    }

    public ResultadoLevelsDto coletar()
    {
        string tempoPartida = provedorDadosTempo.fornecer();
        ResultadoLevelsDto resultadoLevelsDto = new ResultadoLevelsDto(tempoPartida, 0);
        return resultadoLevelsDto;
    }
}
