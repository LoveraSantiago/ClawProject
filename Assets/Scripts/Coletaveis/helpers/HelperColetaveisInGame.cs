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

    public bool temColetavelInGameByNome(string name)
    {
        return poolDeColetaveis.contemNome(name);
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

    public void fixarTodosColetaveisEixoXY()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new FixadorEixosXY());
    }

    public void desafixarTodosColetaveisXY()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new DesafixadorEixosXY());
    }

    public bool isAlgumColetavelAcimaDaHaltura(float haltura)
    {
        return poolDeColetaveis.temEmAlgumColetavel(new AcimaHalturaColetavel(haltura));
    }

    public void inativarColetavel(ColetavelTile coletado)
    {
        poolDeColetaveis.inativarColetavel(coletado);
    }

    public static void configurar()
    {
        poolDeColetaveis = new PoolDeColetaveis(); ;        
    }
}
