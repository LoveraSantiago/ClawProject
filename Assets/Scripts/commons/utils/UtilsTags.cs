using UnityEngine;

public class UtilsTags 
{
    public static bool isColetavel(Collision2D collision)
    {
        return isColetavel(collision.gameObject);
    }

    public static bool isColetavel(GameObject gameObject)
    {
        return gameObject.CompareTag("Coletavel");
    }

    public static bool isNome(Collider2D collider, string nomeTag)
    {
        return collider.gameObject.CompareTag(nomeTag);
    }

    public static bool isNome(Collision2D collision, string nomeTag)
    {
        return collision.gameObject.CompareTag(nomeTag);
    }
}
