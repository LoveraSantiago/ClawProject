public class NavegacaoDeArray<T>
{
    private T[] array;
    public int indiceAtual { get; private set; }

    public NavegacaoDeArray()
    {
    }

    public NavegacaoDeArray(T[] array)
        :this(array, 0){}

    public NavegacaoDeArray(T[] array, int indiceInicial)
    {
        setArray(array, indiceInicial);        
    }

    public T getItemIndiceAtual()
    {
        return array[indiceAtual];
    }

    public T getItemDoIndice(int indice)
    {
        return array[indice];
    }

    public T getItemProximo()
    {
        if (indiceAtual == array.Length - 1)
        {
            indiceAtual = 0;
        }
        else
        {
            incrementar();
        }
        return getItemIndiceAtual();
    }

    public T getItemAnterior()
    {
        if (indiceAtual == 0)
        {
            indiceAtual = array.Length - 1;
        }
        else
        {
            decrementar();
        }
        return getItemIndiceAtual();
    }

    public int incrementar()
    {
        indiceAtual++;
        return indiceAtual;
    }

    public int decrementar()
    {
        indiceAtual--;
        return indiceAtual;
    }    

    public void setArray(T[] array, int indiceInicial)
    {
        this.array = array;
        setIndiceAtual(indiceInicial);
    }

    public void setIndiceAtual(int indice)
    {
        int indiceSanitizado = indice < 0 ? 0 : indice;
        indiceSanitizado = indiceSanitizado >= array.Length ? indiceSanitizado % array.Length : indiceSanitizado;
        indiceAtual = indiceSanitizado;
    }

    public int getTamanhoArray()
    {
        return array.Length;
    }

    public bool isIndiceAtualMenorQtdItensArray()
    {
        return indiceAtual < array.Length;
    }    
}
