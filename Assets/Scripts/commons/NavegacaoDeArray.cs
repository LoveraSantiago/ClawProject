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
            indiceAtual++;
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
            indiceAtual--;
        }
        return getItemIndiceAtual();
    }

    public void setIndiceAtual(int indice)
    {
        indiceAtual = indice;
    }
}
