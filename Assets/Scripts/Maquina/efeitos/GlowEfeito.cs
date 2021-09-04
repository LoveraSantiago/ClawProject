using UnityEngine;

public class GlowEfeito 
{
    private static Color greenHdr;
    private static Color redHdr;
    private static Color yellowHdr;

    private GameObject goEfeito;
    public MaterialGlow materialGlow { get; private set; }

    public GlowEfeito(GameObject goEfeito, MaterialGlow materialGlow)
    {
        this.goEfeito = goEfeito;
        this.materialGlow = materialGlow;
    }

    public void mudarMaterial(MaterialGlow materialGlow)
    {
        this.materialGlow = materialGlow;
    }

    public void ligarGlowSucesso()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(greenHdr);
    }

    public void ligarGlowFail()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(redHdr);
    }

    public void ligarGlowLuz()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(yellowHdr);
    }

    public void desligarGlow()
    {
        goEfeito.SetActive(false);
    }      

    public static void configurarHdr(float factorHdr)
    {
        greenHdr  = HSBColor.toHdrColor(Color.green , factorHdr);
        redHdr    = HSBColor.toHdrColor(Color.red   , factorHdr);
        yellowHdr = HSBColor.toHdrColor(Color.yellow, factorHdr);
    }
}
