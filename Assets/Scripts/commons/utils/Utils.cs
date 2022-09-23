using UnityEngine;

public class Utils 
{
    public static Color getCorByHex(string hex)
    {
        Color cor;
        ColorUtility.TryParseHtmlString(hex, out cor);
        return cor;
    }  

    public static T[] copiarArray<T>(T[] array)
    {
        T[] result = new T[array.Length];
        for(int contador = 0; contador < array.Length; contador++)
        {
            result[contador] = array[contador];
        }
        return result;
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

    public static bool isBlank(string valor)
    {
        return valor == null || "".Equals(valor);
    }
}
