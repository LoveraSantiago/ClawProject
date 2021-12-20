using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenericPool<K, V>
{
    private V objetoTemp;
    private Dictionary<K, V> dicionario;

    public GenericPool()
    {
        dicionario = new Dictionary<K, V>();
    }

    public bool contemNome(K chave)
    {
        return dicionario.ContainsKey(chave);
    }

    public V getObjetoPeloNome(K chave)
    {
        return dicionario[chave];
    }

    public void executeSeTiverObjeto(K chave, Consumidor<V> consumidor)
    {
        if (contemNome(chave))
        {
            objetoTemp = getObjetoPeloNome(chave);
            consumidor.consumir(objetoTemp);
        }
    }

    public void executeEmTodosOsObj(Consumidor<V> consumidor)
    {
        foreach (KeyValuePair<K, V> entry in dicionario)
        {
            consumidor.consumir(entry.Value);
        }
    }

    public bool temEmAlgum(Predicate<V> predicate)
    {
        foreach (KeyValuePair<K, V> entry in dicionario)
        {
            bool result = predicate.test(entry.Value);
            if (result) return true;
        }
        return false;
    }

    public void removerObjetoDoDicionario(K chave)
    {
        if (contemNome(chave))
        {
            dicionario.Remove(chave);
        }
        else
        {
            Debug.LogError("Solicitado retirada de objeto que nao existe no dicionario " + chave);
        }
    }

    public void limpar()
    {
        dicionario.Clear();
    }

    public void addObjetoAoDicionario(K chave, V objeto)
    {
        if (!dicionario.ContainsKey(chave))
        {
            dicionario.Add(chave, objeto);
        }
    }

    public List<V> getListaDeObjetos()
    {        
        return dicionario.Values.ToList();
    }

    public V[] getArrayDeObjetos()
    {
        V[] values = new V[dicionario.Count];
        dicionario.Values.CopyTo(values, 0);
        return values;
    }

    public int getTamanhoDoPool()
    {
        return dicionario.Count;
    }
}
