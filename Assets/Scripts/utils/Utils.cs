using UnityEngine;

public class Utils 
{
    public static bool isColetavel(Collision2D collision)
    {
        return isColetavel(collision.gameObject);
    }

    public static bool isColetavel(GameObject gameObject)
    {
        return !gameObject.CompareTag("Container");
    }
}
