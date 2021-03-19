using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{
    public static bool isColetavel(Collision2D collision)
    {
        return !collision.gameObject.CompareTag("Container");
    }
}
