using UnityEngine;

public class PlayerPrefsGarra
{
    private static readonly string CHAVE_GARRA = "garra";

    public static int getEscolhaGarra()
    {
        int resultado = PlayerPrefs.GetInt(CHAVE_GARRA);        
        return resultado;
    }

    public static Genero getGarraMachoOrFemea()
    {
        int resultado = getEscolhaGarra();
        if (resultado == 0)
        {
            resultado = MathUtils.escolherDeZeroAteLimite(1) + 1;
        }
        return GeneroUtils.getGeneroDoIndice(resultado);
    }

    public static void saveEscolhaGarraRandom()
    {
        saveEscolhaTipoGarra(Genero.NAO_ESCOLHIDO);
    }

    public static void saveEscolhaGarraMacho()
    {
        saveEscolhaTipoGarra(Genero.MACHO);
    }

    public static void saveEscolhaGarraFemea()
    {
        saveEscolhaTipoGarra(Genero.FEMEA);
    }

    private static void saveEscolhaTipoGarra(Genero genero)
    {
        PlayerPrefs.SetInt(CHAVE_GARRA, GeneroUtils.getIndiceDoGenero(genero));
    }
}
