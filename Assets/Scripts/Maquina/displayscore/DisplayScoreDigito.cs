using UnityEngine;

public class DisplayScoreDigito 
{
    private SpriteRenderer[][] arrayDeLeds;

    public int digito { get; private set; }
    public string letra { get; private set; }

    private Color corOriginal;

    private int[,] arrayLigados;

    public DisplayScoreDigito(SingleDisplayScoreDto singleDisplayDto)
    {
        arrayDeLeds = new SpriteRenderer[5][];
        arrayDeLeds[0] = singleDisplayDto.Fileira1;
        arrayDeLeds[1] = singleDisplayDto.Fileira2;
        arrayDeLeds[2] = singleDisplayDto.Fileira3;
        arrayDeLeds[3] = singleDisplayDto.Fileira4;
        arrayDeLeds[4] = singleDisplayDto.Fileira5;
        
        corOriginal = arrayDeLeds[0][0].color;

        arrayLigados = ARRAY_VAZIO;
        mostrarDigito(0, Color.red);
    }

    public void mostrarDigito(string digito, Color cor)
    {
        letra = digito;
        desligarPosicoes(arrayLigados);
        arrayLigados = getArrayParaLigar(digito);
        ligarPosicoes(arrayLigados, cor);
    }

    public void mostrarDigito(int digito, Color cor)
    {
        this.digito = digito;
        desligarPosicoes(arrayLigados);
        arrayLigados = getArrayParaLigar(digito);
        ligarPosicoes(arrayLigados, cor);
    }    

    public void desligarDigito()
    {
        desligarPosicoes(arrayLigados);
    }

    private void ligarPosicoes(int[,] array, Color cor)
    {
        for(int contadorX = 0; contadorX < array.GetLength(0); contadorX++)
        {            
            arrayDeLeds[array[contadorX, 0]][array[contadorX, 1]].color = cor;            
        }
    }

    private void desligarPosicoes(int[,] array)
    {
        if (array == null) return;
        ligarPosicoes(array, corOriginal);        
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
            case "Y": return ARRAY_Y;
            case "E": return ARRAY_E;
            case "S": return ARRAY_S;
            case "!": return ARRAY_EXCLAMACAO;
            case "*": return ARRAY_ASTERISCO;
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

    private static int[,] ARRAY_EXCLAMACAO = new int[,] { { 2, 0 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 } };
    private static int[,] ARRAY_ASTERISCO  = new int[,] { { 0, 1 }, { 0, 5 }, { 1, 2 }, { 1, 4 }, { 2, 0 }, { 2, 1 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 3, 2 }, { 3, 4 }, { 4, 1 }, { 4, 5 }};

}
