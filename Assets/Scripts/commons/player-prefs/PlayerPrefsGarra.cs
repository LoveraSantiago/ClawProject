using UnityEngine;

public class PlayerPrefsGarra
{
    private static readonly string CHAVE_GARRA = "garra";

    public static int getEscolhaGarra()
    {
        int resultado = PlayerPrefs.GetInt(CHAVE_GARRA);        
        return resultado;
    }

    public static int getGarraMachoOrFemea()
    {
        int resultado = getEscolhaGarra();
        if (resultado == 0)
        {
            resultado = MathUtils.escolherDeZeroAteLimite(1) + 1;
        }
        return resultado;
    }

    public static void saveEscolhaGarraRandom()
    {
        saveEscolhaTipoGarra(0);
    }

    public static void saveEscolhaGarraMacho()
    {
        saveEscolhaTipoGarra(1);
    }

    public static void saveEscolhaGarraFemea()
    {
        saveEscolhaTipoGarra(2);
    }

    private static void saveEscolhaTipoGarra(int escolha)
    {
        PlayerPrefs.SetInt(CHAVE_GARRA, escolha);
    }
}
