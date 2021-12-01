using UnityEngine;

public class DisplayScoreDigito 
{
    private static SegmentosScore segmentos;
    private static Material materialEfeitoLed;

    private int[,] arrayLigados;
    public int digito { get; private set; }
    public string letra { get; private set; }

    private Color corOriginal;
    private GlowEfeito glowEfeito;
    private SpriteRenderer sprDisplay;
    private SpriteRenderer[][] arrayDeLeds;
    private Material defaultMaterial;

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

    public void configuradoPeloLevel(string corScore, string corLeds)
    {
        corOriginal = Utils.getCorByHex(corLeds);
        sprDisplay.color = Utils.getCorByHex(corScore);
        defaultMaterial = arrayDeLeds[0][0].sharedMaterial;

        ligarPosicoes(segmentos.ARRAY_CHEIO, corOriginal, defaultMaterial);

        mostrarDigito(0, Color.red);
    }

    public void mostrarDigito(string digito, Color cor)
    {
        letra = digito;
        desligarPosicoes(arrayLigados);
        arrayLigados = segmentos.getArrayParaLigar(digito);
        ligarPosicoes(arrayLigados, cor, materialEfeitoLed);
    }

    public void mostrarDigito(int digito, Color cor)
    {
        this.digito = digito;
        desligarPosicoes(arrayLigados);
        arrayLigados = segmentos.getArrayParaLigar(digito);
        ligarPosicoes(arrayLigados, cor, materialEfeitoLed);
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
            sprLed.material = material;
        }
    }

    private void desligarPosicoes(int[,] array)
    {
        if (array == null) return;
        ligarPosicoes(array, corOriginal, defaultMaterial);        
    }

    public static void configurar()
    {
        segmentos = new SegmentosScore();
        materialEfeitoLed = MaterialHdr.ofLed();
    }
}
