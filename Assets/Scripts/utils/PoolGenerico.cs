using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolGenerico<T> 
{
    private T objetoTemp;
    private Dictionary<string, T> poolDeObjetosPorNome;

    public PoolGenerico()
    {
        poolDeObjetosPorNome = new Dictionary<string, T>();
    }

    public bool contemNome(string nome)
    {
        return poolDeObjetosPorNome.ContainsKey(nome);
    }

    public T getObjetoPeloNome(string nome)
    {
        return poolDeObjetosPorNome[nome];
    }

    public void executeSeTiverObjeto(string nome, ConsumidorDeEvento<T> consumidor)
    {
        if (contemNome(nome))
        {
            objetoTemp = getObjetoPeloNome(nome);
            consumidor.consumirEvento(objetoTemp);            
        }
    }

    public void executeEmTodosOsObj(ConsumidorDeEvento<T> consumidor)
    {
        foreach (KeyValuePair<string, T> entry in poolDeObjetosPorNome)
        {
            consumidor.consumirEvento(entry.Value);
        }
    }

    public void removerObjetoDoDicionario(string nome)
    {
        if (contemNome(nome))
        {
            poolDeObjetosPorNome.Remove(nome);
        }
        else
        {
            Debug.LogError("Solicitado retirada de objeto que nao existe no dicionario " + nome);
        }
    }

    public void limpar()
    {
        poolDeObjetosPorNome.Clear();
    }

    public void addObjetoAoDicionario(string nome, T objeto)
    {
        if (!poolDeObjetosPorNome.ContainsKey(nome))
        {
            poolDeObjetosPorNome.Add(nome, objeto);
        }
    }

    public List<T> getListaDeObjetos()
    {
        return poolDeObjetosPorNome.Values.ToList();
    }
}
