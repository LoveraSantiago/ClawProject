public class PoolDeColetaveis 
{
    private PoolGenerico<Coletavel> poolDeNomes;

    public PoolDeColetaveis()
    {
        poolDeNomes = new PoolGenerico<Coletavel>();
    }

    public Coletavel criarColetavel()
    {
        Coletavel coletavel = new Coletavel();
        poolDeNomes.addObjetoAoDicionario(coletavel.nome, coletavel);
        return coletavel;
    }

    public Coletavel getColetavelPeloNome(string nome)
    {
        return poolDeNomes.getObjetoPeloNome(nome);
    }

    public void executeEmTodosColetaveis(ConsumidorDeEvento<Coletavel> consumidor)
    {
        poolDeNomes.executeEmTodosOsObj(consumidor);
    }
}
