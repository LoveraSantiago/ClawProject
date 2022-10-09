public class ColetorDeDados 
{
    private ProvedorDadosTempo provedorDadosTempo;

    public ColetorDeDados addProvedorDadosTempo(ProvedorDadosTempo provedorDadosTempo)
    {
        this.provedorDadosTempo = provedorDadosTempo;
        return this;
    }

    public ResultadoLevelsDto coletar()
    {
        string tempoPartida = provedorDadosTempo.getTempoPartida();
        ResultadoLevelsDto resultadoLevelsDto = new ResultadoLevelsDto(tempoPartida, 0);
        return resultadoLevelsDto;
    }
}
