public class PoolDeColetaveis 
{
    private PoolGenerico<ColetavelTile> poolDeNomes;

    public PoolDeColetaveis()
    {
        poolDeNomes = new PoolGenerico<ColetavelTile>();
    }

    public ColetavelTile criarColetavel()
    {
        ColetavelTile coletavel = new ColetavelTile();
        poolDeNomes.addObjetoAoDicionario(coletavel.nome, coletavel);
        return coletavel;
    }

    public ColetavelTile getColetavelPeloNome(string nome)
    {
        return poolDeNomes.getObjetoPeloNome(nome);
    }

    public void executeEmTodosColetaveis(ConsumidorDeEvento<ColetavelTile> consumidor)
    {
        poolDeNomes.executeEmTodosOsObj(consumidor);
    }
}
