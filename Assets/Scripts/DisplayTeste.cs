using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTeste : MonoBehaviour
{
    private SpriteRenderer[,] arrayDeLeds = new SpriteRenderer[5,7];
    private int contadorX;
    private int contadorY;

    private Color corOriginal;

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
        StartCoroutine(colorindo());
    }

    private IEnumerator colorindo()
    {
        while (true)
        {
            int[,] arrayLigar = getArrayParaLigar(1);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(2);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(3);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(4);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(5);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(6);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(7);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(8);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(9);
            ligarPosicoes(arrayLigar);
            yield return new WaitForSeconds(1f);

            desligarPosicoes(arrayLigar);
            arrayLigar = getArrayParaLigar(0);
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

            case 0:
                return new int[,] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 1, 0 }, { 1, 2 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 4 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 3 }, { 4, 4 }, { 4, 5 } };
            case 1:
                return new int[,] { { 1,0 }, { 1,5 }, { 2,0 }, { 2, 1 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 3, 0 } };
            case 2:
                return new int[,] { { 0, 0 }, { 0, 1 }, { 0, 5 }, { 1, 0 }, { 1, 2 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 0 }, { 4, 4 }, { 4, 5 } };
            case 3:
                return new int[,] { { 0, 1 }, { 0, 6 }, { 1, 0 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 4 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 5 }, { 4, 6 } };
            case 4:
                return new int[,] { { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 4 }, { 2, 2 }, { 2, 5 }, { 3, 0 }, { 3, 1 }, { 3, 2 }, { 3, 3 }, { 3, 4 }, { 3, 5 }, { 3, 6 }, { 4, 2 } };
            case 5:
                return new int[,] { { 0, 1 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 1, 0 }, { 1, 4 }, { 1, 6 }, { 2, 0 }, { 2, 4 }, { 2, 6 }, { 3, 0 }, { 3, 4 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 3 }, { 4, 6 } };
            case 6:
                return new int[,] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 1, 0 }, { 1, 3 }, { 1, 5 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 6 }};
            case 7:
                return new int[,] { { 0, 6 }, { 1, 0 }, { 1, 1 }, { 1, 2 }, { 1, 6 }, { 2, 3 }, { 2, 6 }, { 3, 4 }, { 3, 6 }, { 4, 5 }, { 4, 6 }};
            case 8:
                return new int[,] { { 0, 1 }, { 0, 2 }, { 0, 4 }, { 0, 5 }, { 1, 0 }, { 1, 3 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 4 }, { 4, 5 } };
            case 9:
                return new int[,] { { 0, 0 }, { 0, 4 }, { 0, 5 }, { 1, 0 }, { 1, 3 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 1 }, { 3, 3 }, { 3, 6 }, { 4, 2 }, { 4, 3 }, { 4, 4 }, { 4, 5}};
        }
        return null;
    }
}
