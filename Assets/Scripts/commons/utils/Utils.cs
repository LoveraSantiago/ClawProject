using UnityEngine;

public class Utils 
{
    public static MonoBehaviour MonoBehaviour { get; private set; }

    public static void configMainMono(MonoBehaviour monoBehaviour)
    {
        MonoBehaviour = monoBehaviour;
    }

    public static Color getCorByHex(string hex)
    {
        Color cor;
        ColorUtility.TryParseHtmlString(hex, out cor);
        return cor;
    }  

}
