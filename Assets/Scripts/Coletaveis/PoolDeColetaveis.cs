public class PoolDeColetaveis 
{
    private PoolList<ColetavelTile> poolInativos;
    private PoolDeNomes<ColetavelTile> poolDeNomes;

    public PoolDeColetaveis()
    {
        poolInativos = new PoolList<ColetavelTile>();
        poolDeNomes = new PoolDeNomes<ColetavelTile>();
    }

    public ColetavelTile criarColetavel()
    {
        if (poolInativos.hasObjeto())
        {
            ColetavelTile coletavel = poolInativos.getObjeto();
            return coletavel;
        }
        else
        {
            ColetavelTile coletavel = new ColetavelTile();
            poolDeNomes.addObjetoAoDicionario(coletavel.nome, coletavel);
            return coletavel;
        }
    }

    public ColetavelTile getColetavelPeloNome(string nome)
    {
        return poolDeNomes.getObjetoPeloNome(nome);
    }

    public void executeEmTodosColetaveis(Consumidor<ColetavelTile> consumidor)
    {
        poolDeNomes.executeEmTodosOsObj(consumidor);
    }

    public bool temEmAlgumColetavel(Predicate<ColetavelTile> predicate)
    {
        return poolDeNomes.temEmAlgum(predicate);
    }

    public void inativarColetaveis(ColetavelTile[] coletaveis)
    {
        for(int contador = 0; contador < coletaveis.Length; contador++)
        {
            inativarColetavel(coletaveis[contador]);
        }
    }

    public void inativarColetavel(ColetavelTile coletavel)
    {
        poolInativos.addObjeto(coletavel);
    }

    public int getQtdDeColetaveis()
    {
        return poolDeNomes.getTamanhoDoPool();
    }

    public bool contemNome(string nome)
    {
        return poolDeNomes.contemNome(nome);
    }
}
