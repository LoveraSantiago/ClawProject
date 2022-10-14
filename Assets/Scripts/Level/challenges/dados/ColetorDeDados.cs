public class ColetorDeDados 
{    
    private Fornecedor<string> provedorDadosTempo;    
    private Fornecedor<int> provedorSubidasDaGarra;
    private Fornecedor<ResultadoColetaveisDto> provedorDadosColetaveis;

    public ColetorDeDados addProvedorDadosTempo(Fornecedor<string> provedorDadosTempo)
    {
        this.provedorDadosTempo = provedorDadosTempo;
        return this;
    }   

    public ColetorDeDados addProvedorDadosColetaveis(Fornecedor<ResultadoColetaveisDto> provedorDadosColetaveis)
    {
        this.provedorDadosColetaveis = provedorDadosColetaveis;
        return this;
    }

    public ColetorDeDados addProvedorSubidasDaGarra(Fornecedor<int> provedorSubidasDaGarra)
    {
        this.provedorSubidasDaGarra = provedorSubidasDaGarra;
        return this;
    }

    public ResultadoLevelDto coletar()
    {
        string tempoPartida = provedorDadosTempo.fornecer();        
        int subidasDaGarra = provedorSubidasDaGarra.fornecer();
        ResultadoColetaveisDto resultadoColetaveis = provedorDadosColetaveis.fornecer();

        ResultadoLevelDto resultadoLevelsDto = new ResultadoLevelDto(tempoPartida, resultadoColetaveis, subidasDaGarra);
        return resultadoLevelsDto;
    }
}
