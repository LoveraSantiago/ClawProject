using UnityEngine;

public class DisplayScoreDigito 
{
    private static ContextoEstaticoDisplayScoresDigito contexto;

    private int[,] arrayLigados;
    public int digito { get; private set; }
    public string letra { get; private set; }
    
    private GlowEfeito glowEfeito;
    private SpriteRenderer sprDisplay;
    private SpriteRenderer[][] arrayDeLeds;    

    public DisplayScoreDigito(SingleDisplayScoreDto singleDisplayDto)
    {
        sprDisplay = singleDisplayDto.SprRendererPlaca;
        arrayDeLeds = new SpriteRenderer[5][];
        arrayDeLeds[0] = singleDisplayDto.Fileira1;
        arrayDeLeds[1] = singleDisplayDto.Fileira2;
        arrayDeLeds[2] = singleDisplayDto.Fileira3;
        arrayDeLeds[3] = singleDisplayDto.Fileira4;
        arrayDeLeds[4] = singleDisplayDto.Fileira5;
        
        glowEfeito = new GlowEfeito(singleDisplayDto.PlacaEfeito, singleDisplayDto.MaterialEfeito);
    }

    public void configuradoPeloLevel(string corScore)
    {   
        sprDisplay.color = Utils.getCorByHex(corScore);
        ligarPosicoes(contexto.Segmentos.ARRAY_CHEIO, contexto.CorOriginalLed, contexto.DefaultMaterial);

        mostrarDigito(0, Color.red);
    }

    public void mostrarDigito(string digito, Color cor)
    {
        letra = digito;
        desligarPosicoes(arrayLigados);
        arrayLigados = contexto.Segmentos.getArrayParaLigar(digito);
        ligarPosicoes(arrayLigados, cor, contexto.MaterialEfeitoLed);
    }

    public void mostrarDigito(int digito, Color cor)
    {
        this.digito = digito;
        desligarPosicoes(arrayLigados);
        arrayLigados = contexto.Segmentos.getArrayParaLigar(digito);
        ligarPosicoes(arrayLigados, cor, contexto.MaterialEfeitoLed);
    }    

    public void desligarDigito()
    {
        desligarPosicoes(arrayLigados);
    }

    public void ligarGlowSucesso()
    {
        glowEfeito.ligarGlowSucesso();
    }

    public void desligarGlow()
    {
        glowEfeito.desligarGlow();
    }    

    public MaterialGlow getMaterialGlow()
    {
        return glowEfeito.materialGlow;
    }

    private void ligarPosicoes(int[,] array, Color cor, Material material)
    {
        for(int contadorX = 0; contadorX < array.GetLength(0); contadorX++)
        {
            SpriteRenderer sprLed = arrayDeLeds[array[contadorX, 0]][array[contadorX, 1]];
            sprLed.color = cor;
            sprLed.sharedMaterial = material;
        }
    }

    private void desligarPosicoes(int[,] array)
    {
        if (array == null) return;
        ligarPosicoes(array, contexto.CorOriginalLed, contexto.DefaultMaterial);        
    } 
    
    public static void configurar(Material materialEfeitoLedArg, Material defaultMaterialArg, Color corOriginalLed)
    {
        contexto = new ContextoEstaticoDisplayScoresDigito(materialEfeitoLedArg, defaultMaterialArg, corOriginalLed);
    }
}
