using UnityEngine;

public class PlayerPrefsUtils 
{
    private static readonly string PUP = "PUP";    

    public static void salvarIndicePup(int indicePup)
    {
        PlayerPrefs.SetInt(PUP, indicePup);
    }

    public static int recuperarIndicePup()
    {
        int indiceSalvo = PlayerPrefs.GetInt(PUP);        
        return indiceSalvo;
    }
}
