using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTeste : MonoBehaviour
{
    private SpriteRenderer[,] arrayDeLeds = new SpriteRenderer[5,7];
    private int contadorX;
    private int contadorY;

    private Color corOriginal;
    //private Color corBranca = Color.white;

    //private Color corSim;
    //private Color corNao;

    void Start()
    {
        for(contadorX = 0; contadorX < transform.childCount; contadorX++)
        {            
            Transform transfFileira = transform.GetChild(contadorX);
            for(contadorY = 0; contadorY < transfFileira.childCount; contadorY++)
            {         
                Transform transformLed = transfFileira.GetChild(contadorY);         
                arrayDeLeds[contadorX, contadorY] = transformLed.GetComponent<SpriteRenderer>();
            }
        }
        corOriginal = arrayDeLeds[0, 0].color;
        //trocarCores();
        StartCoroutine(colorindo());
    }

    //private void trocarCores()
    //{
    //    if(corSim == corVermelha)
    //    {
    //        corSim = corVermelha;
    //        corNao = corBranca;
    //    }
    //    else
    //    {
    //        corSim = corBranca;
    //        corNao = corVermelha;
    //    }
    //}

    private IEnumerator colorindo()
    {
        while (true)
        {

            //    int contadorGeral = 0;
            //    for (contadorX = 0; contadorX < 5; contadorX++)
            //    {
            //        Transform transfFileira = transform.Find("fileira" + (contadorX + 1));
            //        for (contadorY = 0; contadorY < 7; contadorY++)
            //        {                    
            //            if(contadorGeral % 2== 0)
            //            {
            //                arrayDeLeds[contadorX, contadorY].color = corSim;
            //            }
            //            else
            //            {
            //                arrayDeLeds[contadorX, contadorY].color = corNao;
            //            }
            //            contadorGeral++;
            //        }
            //    }
            //    //trocarCores();
            //    yield return new WaitForSeconds(2f);

            //    contadorGeral = 0;
            //    for (contadorX = 0; contadorX < 5; contadorX++)
            //    {
            //        Transform transfFileira = transform.Find("fileira" + (contadorX + 1));
            //        for (contadorY = 0; contadorY < 7; contadorY++)
            //        {
            //            if (contadorGeral % 2 == 0)
            //            {
            //                arrayDeLeds[contadorX, contadorY].color = corNao;
            //            }
            //            else
            //            {
            //                arrayDeLeds[contadorX, contadorY].color = corSim;
            //            }
            //            contadorGeral++;
            //        }
            //    }

            
            int[,] arrayLigar = getArrayParaLigar(1);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(2);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
        }
        //yield return null;
    }

    private void ligarPosicoes(int[,] array)
    {
        for(contadorX = 0; contadorX < array.GetLength(0); contadorX++)
        {            
            arrayDeLeds[array[contadorX, 0], array[contadorX, 1]].color = Color.red;            
        }
    }

    private void desligarPosicoes(int[,] array)
    {
        if (array == null) return;
        for (contadorX = 0; contadorX < array.GetLength(0); contadorX++)
        {
            arrayDeLeds[array[contadorX, 0], array[contadorX, 1]].color = corOriginal;
        }
    }

    private int[,] getArrayParaLigar(int caracter)
    {
        switch(caracter){

            case 1:
                return new int[,] { { 1,0 }, { 1,5 }, { 2,0 }, { 2, 1 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 3, 0 } };
            case 2:
                return new int[,] { { 0, 0 }, { 0, 1 }, { 0, 5 }, { 1, 0 }, { 1, 2 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 0 }, { 4, 4 }, { 4, 5 } };
        }
        return null;
    }
}
