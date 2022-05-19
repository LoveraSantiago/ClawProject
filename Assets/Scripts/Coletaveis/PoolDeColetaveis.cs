using System.Collections.Generic;
using UnityEngine;

public class PoolDeColetaveis 
{
    private PoolList<Coletavel> poolInativos;
    private PoolDeNomes<Coletavel> poolDeNomes;

    public PoolDeColetaveis()
    {
        poolInativos = new PoolList<Coletavel>();
        poolDeNomes = new PoolDeNomes<Coletavel>();
    }

    public Coletavel criarColetavel()
    {
        if (poolInativos.hasObjeto())
        {
            return poolInativos.getObjeto();            
        }
        else
        {
            Coletavel coletavel = new Coletavel();
            poolDeNomes.addChaveValor(coletavel.nome, coletavel);
            return coletavel;
        }
    }

    public Coletavel criarColetavel(GameObject goParent)
    {
        if (poolInativos.hasObjeto())
        {
            return poolInativos.getObjeto();            
        }
        else
        {
            Coletavel coletavel = new Coletavel();
            poolDeNomes.addChaveValor(coletavel.nome, coletavel);
            return coletavel;
        }
    }

    public Coletavel getColetavelPeloGoNome(string nome)
    {
        return poolDeNomes.getValor(nome);
    }   

    public void executeEmTodosColetaveis(Consumidor<Coletavel> consumidor)
    {
        poolDeNomes.executeEmTodosOsValores(consumidor);
    }

    public bool temEmAlgumColetavel(Predicate<Coletavel> predicate)
    {
        return poolDeNomes.temEmAlgumValor(predicate);
    }

    public Coletavel[] getTrincaDeColetaveis(ColetavelEntidade coletavelEntidade)
    {
        List<Coletavel> listaColetaveis = poolDeNomes.getListaDeValores();
        List<Coletavel> listaResult = new List<Coletavel>(3);
        for(int contador = 0; contador < listaColetaveis.Count && listaResult.Count <3; contador++)
        {
            Coletavel coletavelIt = listaColetaveis[contador];
            if (coletavelIt.getSprite().name.Equals(coletavelEntidade.nomeSprite))
            {
                listaResult.Add(coletavelIt);
            }
        }
        return listaResult.ToArray();
    }

    public void inativarColetaveis(Coletavel[] coletaveis)
    {
        for(int contador = 0; contador < coletaveis.Length; contador++)
        {
            inativarColetavel(coletaveis[contador]);
        }
    }

    public void inativarColetavel(Coletavel coletavel)
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
