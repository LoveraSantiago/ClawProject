public class GeneroUtils
{
    private static readonly int INDICE_NAO_ESCOLHIDO = 0;
    private static readonly int INDICE_MACHO         = 1;
    private static readonly int INDICE_FEMEA         = 2;

    public static int getIndiceDoGenero(Genero genero)
    {
        if (isGeneroMacho(genero))
        {
            return INDICE_MACHO;
        }
        else if (isGeneroFemea(genero))
        {
            return INDICE_FEMEA;
        }
        return INDICE_NAO_ESCOLHIDO;
    }

    public static bool isGeneroMacho(Genero genero)
    {
        if(genero == Genero.MACHO)
        {
            return true;
        }
        return false;
    }

    public static bool isGeneroFemea(Genero genero)
    {
        if(genero == Genero.FEMEA)
        {
            return true;
        }
        return false;
    }

    public static Genero getGeneroDoIndice(int indice)
    {
        if(indice == INDICE_NAO_ESCOLHIDO)
        {
            return Genero.NAO_ESCOLHIDO;
        }
        else if(indice == INDICE_MACHO)
        {
            return Genero.MACHO;
        }
        return Genero.FEMEA;
    }
}
