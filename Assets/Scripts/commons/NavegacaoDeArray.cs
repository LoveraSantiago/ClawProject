public class NavegacaoDeArray<T>
{
    private T[] array;
    public int indiceAtual { get; private set; }

    public NavegacaoDeArray(T[] array)
        :this(array, 0){}

    public NavegacaoDeArray(T[] array, int indiceInicial)
    {
        this.array = array;
        setIndiceAtual(indiceInicial);
    }

    public T getItemIndiceAtual()
    {
        return array[indiceAtual];
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

    public void setIndiceAtual(int indice)
    {
        indiceAtual = indice;
    }

    public bool isIndiceAtualMenorQtdItensArray()
    {
        return indiceAtual < array.Length;
    }
}
