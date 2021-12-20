using System.Collections.Generic;

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
            poolDeNomes.addChaveValor(coletavel.nome, coletavel);
            return coletavel;
        }
    }

    public ColetavelTile getColetavelPeloGoNome(string nome)
    {
        return poolDeNomes.getValor(nome);
    }   

    public void executeEmTodosColetaveis(Consumidor<ColetavelTile> consumidor)
    {
        poolDeNomes.executeEmTodosOsValores(consumidor);
    }

    public bool temEmAlgumColetavel(Predicate<ColetavelTile> predicate)
    {
        return poolDeNomes.temEmAlgumValor(predicate);
    }

    public ColetavelTile[] getTrincaDeColetaveis(ColetavelEntidade coletavelEntidade)
    {
        List<ColetavelTile> listaColetaveis = poolDeNomes.getListaDeValores();
        List<ColetavelTile> listaResult = new List<ColetavelTile>(3);
        for(int contador = 0; contador < listaColetaveis.Count && listaResult.Count <3; contador++)
        {
            ColetavelTile coletavelIt = listaColetaveis[contador];
            if (coletavelIt.getSprite().name.Equals(coletavelEntidade.nomeSprite))
            {
                listaResult.Add(coletavelIt);
            }
        }
        return listaResult.ToArray();
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
        return poolDeNomes.contem(nome);
    }
}
