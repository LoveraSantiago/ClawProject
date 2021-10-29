using UnityEngine;

public class Utils 
{
    public static MonoBehaviour MonoBehaviour { get; private set; }
    public static Material materialGrayScale  { get; private set; }

    public static void configMainMono(MonoBehaviour monoBehaviour)
    {
        MonoBehaviour = monoBehaviour;
    }

    public static void configMainMatGrayScale(Material materialGrayScaleArg)
    {
        materialGrayScale = materialGrayScaleArg;
    }

    public static void pauseTime()
    {
        Time.timeScale = 0;
    }

    public static void continuTime()
    {
        Time.timeScale = 1;
    }

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

}
