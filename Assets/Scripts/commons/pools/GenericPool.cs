using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenericPool<K, V>
{    
    private Dictionary<K, V> dicionario;

    public GenericPool()
    {
        dicionario = new Dictionary<K, V>();
    }

    public bool contem(K chave)
    {
        return dicionario.ContainsKey(chave);
    }

    public V getValor(K chave)
    {
        return dicionario[chave];
    }

    public void executeSeTiverChave(K chave, Consumidor<V> consumidor)
    {
        if (contem(chave))
        {
            V objetoTemp = getValor(chave);
            consumidor.consumir(objetoTemp);
        }
    }

    public void executeEmTodosOsValores(Consumidor<V> consumidor)
    {
        for(int contador = 0; contador < dicionario.Count; contador++)
        {
            KeyValuePair<K, V> chaveValor = dicionario.ElementAt(contador);
            consumidor.consumir(chaveValor.Value);
        }
    }

    public void executeEmTodosAsChavesValores(BiConsumidor<K, V> biConsumidor)
    {        
        for(int contador = 0; contador < dicionario.Count; contador++)
        {
            KeyValuePair<K, V> chaveValor = dicionario.ElementAt(contador);
            biConsumidor.consumir(chaveValor.Key, chaveValor.Value);
        }
    }

    public bool temEmAlgumValor(Predicate<V> predicate)
    {
        for (int contador = 0; contador < dicionario.Count; contador++)
        {
            KeyValuePair<K, V> chaveValor = dicionario.ElementAt(contador);
            bool result = predicate.test(chaveValor.Value);
            if (result) return true;
        }
        return false;
    }

    public void remover(K chave)
    {
        if (contem(chave))
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

    public GenericPool<K, V> addChaveValor(K chave, V objeto)
    {
        if (!dicionario.ContainsKey(chave))
        {
            dicionario.Add(chave, objeto);
        }
        return this;
    }

    public List<V> getListaDeValores()
    {        
        return dicionario.Values.ToList();
    }

    public List<K> getListaDeChaves()
    {
        return dicionario.Keys.ToList();
    }

    public V[] getArrayDeValores()
    {
        V[] values = new V[dicionario.Count];
        dicionario.Values.CopyTo(values, 0);
        return values;
    }

    public K[] getArrayDeChaves()
    {
        K[] chaves = new K[dicionario.Count];
        dicionario.Keys.CopyTo(chaves, 0);
        return chaves;
    }

    public int getTamanhoDoPool()
    {
        return dicionario.Count;
    }
}
