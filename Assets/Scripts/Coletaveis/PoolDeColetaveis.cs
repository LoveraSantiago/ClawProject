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
}
