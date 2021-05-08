using UnityEngine;

public class DisplayTimerDigito2Pontos 
{
    private SpriteRenderer[] arrayDeLeds;

    public DisplayTimerDigito2Pontos(GameObject displayTimer2Digitos)
    {
        arrayDeLeds = new SpriteRenderer[2];
        arrayDeLeds[0] = displayTimer2Digitos.transform.Find("seg-1").GetComponent<SpriteRenderer>();
        arrayDeLeds[1] = displayTimer2Digitos.transform.Find("seg-2").GetComponent<SpriteRenderer>();

        arrayDeLeds[0].color = Color.red;
        arrayDeLeds[1].color = Color.red;
    }
}
