using System.Collections.Generic;

public class PoolList<T> 
{
    private List<T> listaDeObjetos;

    public PoolList()
    {
        listaDeObjetos = new List<T>();
    }

    public void addObjeto(T objeto)
    {
        listaDeObjetos.Add(objeto);
    }

    public T getObjeto()
    {
        T objeto = listaDeObjetos[0];
        listaDeObjetos.RemoveAt(0);
        return objeto;
    }

    public void reclicarPool()
    {
        listaDeObjetos.Clear();
    }

    public bool hasObjeto()
    {
        return listaDeObjetos.Count > 0;
    }

    public int getQtd()
    {
        return listaDeObjetos.Count;
    }
}
