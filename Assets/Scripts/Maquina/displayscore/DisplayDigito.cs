using UnityEngine;

public class DisplayDigito 
{
    private SpriteRenderer[,] arrayDeLeds = new SpriteRenderer[5,7];
    private int contadorX;
    private int contadorY;

    public int digito { get; private set; }
    public string letra { get; private set; }

    private Color corOriginal;

    private int[,] arrayLigados;

    public DisplayDigito(GameObject goDisplay)
    {
        Transform transform = goDisplay.transform;
        for (contadorX = 0; contadorX < transform.childCount; contadorX++)
        {            
            Transform transfFileira = transform.GetChild(contadorX);
            for(contadorY = 0; contadorY < transfFileira.childCount; contadorY++)
            {         
                Transform transformLed = transfFileira.GetChild(contadorY);         
                arrayDeLeds[contadorX, contadorY] = transformLed.GetComponent<SpriteRenderer>();
            }
        }
        corOriginal = arrayDeLeds[0, 0].color;

        arrayLigados = ARRAY_VAZIO;
        mostrarDigito(0);
    }

    public void mostrarDigito(string digito)
    {
        letra = digito;
        desligarPosicoes(arrayLigados);
        arrayLigados = getArrayParaLigar(digito);
        ligarPosicoes(arrayLigados, Color.green);
    }

    public void mostrarDigito(int digito)
    {
        this.digito = digito;
        desligarPosicoes(arrayLigados);
        arrayLigados = getArrayParaLigar(digito);
        ligarPosicoes(arrayLigados, Color.red);
    }    

    public void desligarDigito()
    {
        desligarPosicoes(arrayLigados);
    }

    private void ligarPosicoes(int[,] array, Color cor)
    {
        for(contadorX = 0; contadorX < array.GetLength(0); contadorX++)
        {            
            arrayDeLeds[array[contadorX, 0], array[contadorX, 1]].color = cor;            
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

            case 0: return ARRAY_ZERO;                
            case 1: return ARRAY_HUM;                
            case 2: return ARRAY_DOIS;                
            case 3: return ARRAY_TRES;                
            case 4: return ARRAY_QUATRO;                
            case 5: return ARRAY_CINCO;                
            case 6: return ARRAY_SEIS;                
            case 7: return ARRAY_SETE;                
            case 8: return ARRAY_OITO;                
            case 9: return ARRAY_NOVE;                
        }
        return ARRAY_VAZIO;
    }

    private int [,] getArrayParaLigar(string caracter)
    {
        switch (caracter)
        {
            case "Y":
                return ARRAY_Y;
            case "E":
                return ARRAY_E;
            case "S":
                return ARRAY_S;
        }
        return ARRAY_VAZIO;
    }

    private static int[,] ARRAY_VAZIO = new int[,] { };
    private static int[,] ARRAY_ZERO   = new int[,] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 1, 0 }, { 1, 2 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 4 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 3 }, { 4, 4 }, { 4, 5 } };
    private static int[,] ARRAY_HUM    = new int[,] { { 1, 0 }, { 1, 5 }, { 2, 0 }, { 2, 1 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 3, 0 } };
    private static int[,] ARRAY_DOIS   = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 5 }, { 1, 0 }, { 1, 2 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 0 }, { 4, 4 }, { 4, 5 } };
    private static int[,] ARRAY_TRES   = new int[,] { { 0, 1 }, { 0, 6 }, { 1, 0 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 4 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 5 }, { 4, 6 } };
    private static int[,] ARRAY_QUATRO = new int[,] { { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 4 }, { 2, 2 }, { 2, 5 }, { 3, 0 }, { 3, 1 }, { 3, 2 }, { 3, 3 }, { 3, 4 }, { 3, 5 }, { 3, 6 }, { 4, 2 } };
    private static int[,] ARRAY_CINCO  = new int[,] { { 0, 1 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 1, 0 }, { 1, 4 }, { 1, 6 }, { 2, 0 }, { 2, 4 }, { 2, 6 }, { 3, 0 }, { 3, 4 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 3 }, { 4, 6 } };
    private static int[,] ARRAY_SEIS   = new int[,] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 1, 0 }, { 1, 3 }, { 1, 5 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 6 } };
    private static int[,] ARRAY_SETE   = new int[,] { { 0, 6 }, { 1, 0 }, { 1, 1 }, { 1, 2 }, { 1, 6 }, { 2, 3 }, { 2, 6 }, { 3, 4 }, { 3, 6 }, { 4, 5 }, { 4, 6 } };
    private static int[,] ARRAY_OITO   = new int[,] { { 0, 1 }, { 0, 2 }, { 0, 4 }, { 0, 5 }, { 1, 0 }, { 1, 3 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 4 }, { 4, 5 } };
    private static int[,] ARRAY_NOVE   = new int[,] { { 0, 0 }, { 0, 4 }, { 0, 5 }, { 1, 0 }, { 1, 3 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 1 }, { 3, 3 }, { 3, 6 }, { 4, 2 }, { 4, 3 }, { 4, 4 }, { 4, 5 } };

    private static int[,] ARRAY_Y = new int[,] { { 0, 4 }, { 0, 5 }, { 0, 6 }, { 1, 3 }, { 2, 0 }, { 2, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 4, 5 }, { 4, 6 } };
    private static int[,] ARRAY_E = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 1, 0 }, { 1, 3 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 0 }, { 4, 6 } };
    private static int[,] ARRAY_S = new int[,] { { 0, 0 }, { 0, 4 }, { 0, 5 }, { 1, 0 }, { 1, 3 }, { 1, 6 }, { 2, 0 }, { 2, 3 }, { 2, 6 }, { 3, 0 }, { 3, 3 }, { 3, 6 }, { 4, 1 }, { 4, 2 }, { 4, 6 }};
}
