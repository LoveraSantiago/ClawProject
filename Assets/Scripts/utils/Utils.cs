using UnityEngine;

public class Utils 
{
    public static readonly float RATIO_SCREEN = 0.5625f;
    //public static readonly float RATIO_SCREEN = 0.625f;

    public static bool isColetavel(Collision2D collision)
    {
        return isColetavel(collision.gameObject);
    }

    public static bool isColetavel(GameObject gameObject)
    {
        return gameObject.CompareTag("Coletavel");
    }

    public static bool isTag(Collider2D collider, string nomeTag)
    {
        return collider.gameObject.CompareTag(nomeTag);
    }

    public static bool isTag(Collision2D collision, string nomeTag)
    {
        return collision.gameObject.CompareTag(nomeTag);
    }

    public static Color getCorByHex(string hex)
    {
        Color cor;
        ColorUtility.TryParseHtmlString(hex, out cor);
        return cor;
    }

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
}
