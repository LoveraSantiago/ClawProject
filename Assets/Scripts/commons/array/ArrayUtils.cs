public class ArrayUtils 
{
    public static T[] copiarArray<T>(T[] array)
    {
        T[] result = new T[array.Length];
        for (int contador = 0; contador < array.Length; contador++)
        {
            result[contador] = array[contador];
        }
        return result;
    }

    public static T[] adicionarAoArray<T>(T[] array, T item)
    {
        if(array == null)
        {
            T[] result = new T[1];
            result[0] = item;
            return result;
        }
        else
        {
            T[] result = new T[array.Length + 1];
            for (int contador = 0; contador < array.Length; contador++)
            {
                result[contador] = array[contador];
            }
            result[result.Length - 1] = item;
            return result;
        }

    }

    public static int[] criarArrayPopuladoDeInteiros(int tamanhoArray, int valor)
    {
        int[] arrayVazio = new int[tamanhoArray];
        for (int contador = 0; contador < tamanhoArray; contador++)
        {
            arrayVazio[contador] = valor;
        }
        return arrayVazio;
    }

    public static string[] criarArrayPopuladoDeString(int tamanhoArray, string valor)
    {
        string[] arrayVazio = new string[tamanhoArray];
        for (int contador = 0; contador < tamanhoArray; contador++)
        {
            arrayVazio[contador] = valor;
        }
        return arrayVazio;
    }
}
