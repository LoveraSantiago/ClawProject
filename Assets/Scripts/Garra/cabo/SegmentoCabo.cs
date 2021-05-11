using UnityEngine;

public struct SegmentoCabo 
{
    private static float limiteHorizontalMaximo;
    private static float limiteHorizontalMinimo;

    public Vector2 posNow { get; private set; }
    public Vector2 posOld { get; private set; }

    public SegmentoCabo(Vector2 pos)
    {
        this.posNow = pos;
        this.posOld = pos;
    }

    public void setPosNow(Vector2 posNow)
    {
        if (posNow.x < limiteHorizontalMinimo)
        {
            posNow.x = limiteHorizontalMinimo;
        }

        if (posNow.x > limiteHorizontalMaximo)
        {
            posNow.x = limiteHorizontalMaximo;
        }
        this.posNow = posNow;
    }

    public void setPosOld(Vector2 posOld)
    {
        this.posOld = posOld;
    }

    public void addPosNow(Vector2 posNow)
    {
        Vector2 soma = this.posNow + posNow;
        setPosNow(soma);
    }

    public void subPosNow(Vector2 posNow)
    {
        Vector2 sub = this.posNow - posNow;
        setPosNow(sub);
    }

    public static void configurarLimiteHorizontalMaximo(float limite)
    {
        limiteHorizontalMaximo = limite;
    }

    public static void configurarLimiteHorizontalMinimo(float limite)
    {
        limiteHorizontalMinimo = limite;
    }
}
