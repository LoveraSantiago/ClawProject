using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTeste : MonoBehaviour
{
    private SpriteRenderer[,] arrayDeLeds = new SpriteRenderer[5,7];
    private int contadorX;
    private int contadorY;

    private Color corVermelha = Color.red;
    private Color corBranca = Color.white;

    private Color corSim;
    private Color corNao;

    void Start()
    {
        for(contadorX = 0; contadorX < 5; contadorX++)
        {
            string nomeFileira = "fileira" + (contadorX + 1);
            Transform transfFileira = transform.Find(nomeFileira);
            for(contadorY = 0; contadorY < 7; contadorY++)
            {
                //string nomeLed = "led" + (contadorY + 1);
                Transform transformLed = transfFileira.GetChild(contadorY);
                Debug.Log(nomeFileira + transform.name);
                arrayDeLeds[contadorX, contadorY] = transformLed.GetComponent<SpriteRenderer>();
            }
        }
        trocarCores();
        StartCoroutine(colorindo());
    }

    private void trocarCores()
    {
        if(corSim == corVermelha)
        {
            corSim = corVermelha;
            corNao = corBranca;
        }
        else
        {
            corSim = corBranca;
            corNao = corVermelha;
        }
    }

    private IEnumerator colorindo()
    {
        while (true)
        {
            
            int contadorGeral = 0;
            for (contadorX = 0; contadorX < 5; contadorX++)
            {
                Transform transfFileira = transform.Find("fileira" + (contadorX + 1));
                for (contadorY = 0; contadorY < 7; contadorY++)
                {                    
                    if(contadorGeral % 2== 0)
                    {
                        arrayDeLeds[contadorX, contadorY].color = corSim;
                    }
                    else
                    {
                        arrayDeLeds[contadorX, contadorY].color = corNao;
                    }
                    contadorGeral++;
                }
            }
            //trocarCores();
            yield return new WaitForSeconds(2f);

            contadorGeral = 0;
            for (contadorX = 0; contadorX < 5; contadorX++)
            {
                Transform transfFileira = transform.Find("fileira" + (contadorX + 1));
                for (contadorY = 0; contadorY < 7; contadorY++)
                {
                    if (contadorGeral % 2 == 0)
                    {
                        arrayDeLeds[contadorX, contadorY].color = corNao;
                    }
                    else
                    {
                        arrayDeLeds[contadorX, contadorY].color = corSim;
                    }
                    contadorGeral++;
                }
            }
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }
}
