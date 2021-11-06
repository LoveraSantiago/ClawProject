using UnityEngine;

public class UtilsMath 
{
    public static Vector2 lerp(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }

    public static Vector2 quadraticCurve(Vector2 a, Vector2 b, Vector2 c, float t)
    {
        Vector2 p0 = lerp(a, b, t);
        Vector2 p1 = lerp(b, c, t);
        return lerp(p0, p1, t);
    }

    public static Vector2 cubicCurve(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
    {
        Vector2 p0 = quadraticCurve(a, b, c, t);
        Vector2 p1 = quadraticCurve(b, c, d, t);
        return lerp(p0, p1, t);
    }

    public static int escolherDeZeroAteLimite(int limite)
    {        
        return Random.Range(0, limite);
    }

    public static int escolherDeZeroAteLimiteDiferenteDe(int limite, int diferente)
    {
        int sorteado = 0;
        int contador = 0;
        do
        {
            sorteado = escolherDeZeroAteLimite(limite);
            contador++;
        }
        while (sorteado == diferente && contador < 3);

        if (sorteado == diferente)
        {
            if(sorteado != 0)
            {
                sorteado = 0;
            }
            else if(sorteado != limite)
            {
                sorteado = limite;
            }
        }       
        return sorteado;
    }
}
