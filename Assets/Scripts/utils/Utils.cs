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
    
    public class EventoVazioPowerUpFim { }
}
