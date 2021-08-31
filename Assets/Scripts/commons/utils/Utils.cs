using UnityEngine;

public class Utils 
{
    public static Color getCorByHex(string hex)
    {
        Color cor;
        ColorUtility.TryParseHtmlString(hex, out cor);
        return cor;
    }  
}
