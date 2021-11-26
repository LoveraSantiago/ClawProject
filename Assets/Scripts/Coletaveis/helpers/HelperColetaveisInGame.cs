public class HelperColetaveisInGame 
{
    private static PoolDeColetaveis poolDeColetaveis;

    public ColetavelTile criarColetavel()
    {
        return poolDeColetaveis.criarColetavel();
    }

    public int getQtdColetaveisInGame()
    {
        return poolDeColetaveis.getQtdDeColetaveis();
    }

    public ColetavelTile getColetavelInGameByName(string name)
    {
        return poolDeColetaveis.getColetavelPeloNome(name);
    }

    public ColetavelTile getColetavelMaisAlto()
    {
        ProcuradorColetavelMaisAlto procurador = new ProcuradorColetavelMaisAlto();
        poolDeColetaveis.executeEmTodosColetaveis(procurador);
        return procurador.coletavelMaisAlto;
    }    

    public void ligarMiraAlvoFinalNoColetavel(string nomeAlvo)
    {
        poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
    }

    public void ligarMirasNosColetaveis()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeMiras());
    }

    public void desligarMirasNosColetaveis()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new DesligadorDeMiras());
    }

    public static void configurar(PoolDeColetaveis poolDeColetaveisArg)
    {
        poolDeColetaveis = new PoolDeColetaveis(); ;        
    }
}
