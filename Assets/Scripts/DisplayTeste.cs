using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTeste : MonoBehaviour
{
    private SpriteRenderer[,] arrayDeLeds = new SpriteRenderer[8,8];
    private int contadorX;
    private int contadorY;

    void Start()
    {
        for(contadorX = 0; contadorX < 8; contadorX++)
        {
            Transform transfFileira = transform.Find("fileira" + (contadorX + 1));
            for(contadorY = 0; contadorY < 8; contadorY++)
            {
                arrayDeLeds[contadorX, contadorY] = transfFileira.Find("led" + (contadorY + 1)).GetComponent<SpriteRenderer>();
            }
        }

        StartCoroutine(colorindo());
    }

    private IEnumerator colorindo()
    {
        while (true)
        {
            for (contadorX = 0; contadorX < 8; contadorX++)
            {
                Transform transfFileira = transform.Find("fileira" + (contadorX + 1));
                for (contadorY = 0; contadorY < 8; contadorY++)
                {
                    Color corAtual = arrayDeLeds[contadorX, contadorY].color;
                    
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
        yield return null;
    }
}
