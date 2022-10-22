using UnityEngine;

public class TagUtils 
{  
    public static bool isColetavel(Collision2D collision)
    {
        return isColetavel(collision.gameObject);
    }

    public static bool isColetavel(GameObject gameObject)
    {
        return isTag(gameObject, LayerUtils.LAYER_COLETAVEL_DESCRICAO);
    }

    public static bool isGaiola(Collision2D collision)
    {
        return isGaiola(collision.gameObject);
    }

    public static bool isGaiola(GameObject gameObject)
    {
        return isTag(gameObject, LayerUtils.LAYER_GAIOLA_DESCRICAO);
    }

    public static bool isNome(Collider2D collider, string nomeTag)
    {
        return isTag(collider.gameObject, nomeTag);
    }

    public static bool isNome(Collision2D collision, string nomeTag)
    {
        return isTag(collision.gameObject, nomeTag);
    }

    private static bool isTag(GameObject gameObject, string tag)
    {
        return gameObject.CompareTag(tag);
    }
}
