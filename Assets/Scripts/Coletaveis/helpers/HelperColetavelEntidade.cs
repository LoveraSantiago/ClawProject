using UnityEngine;

public class HelperColetavelEntidade 
{
    public static bool isIndiceVazio(int indice)
    {
        return indice == -1;
    }

    public static bool isIndiceRandom(int indice)
    {
        return indice == -2;
    }

    public static int getIndiceSpriteNaoEncontrado(Sprite sprite)
    {
        if ("tile-random".Equals(sprite.name))
        {
            return -2;
        }
        else
        {
            return -1;
        }
    }
}
