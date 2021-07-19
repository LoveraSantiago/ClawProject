public class PoolDeColetaveis 
{
    private PoolDeNomes<ColetavelTile> poolDeNomes;

    public PoolDeColetaveis()
    {
        poolDeNomes = new PoolDeNomes<ColetavelTile>();
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

    public void executeEmTodosColetaveis(Consumidor<ColetavelTile> consumidor)
    {
        poolDeNomes.executeEmTodosOsObj(consumidor);
    }
}
