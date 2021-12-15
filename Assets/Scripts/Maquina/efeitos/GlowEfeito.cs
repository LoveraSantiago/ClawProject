using UnityEngine;

public class GlowEfeito 
{
    private GameObject goEfeito;
    public MaterialGlow materialGlow { get; private set; }

    public GlowEfeito(GameObject goEfeito, Material material)
    {
        this.goEfeito = goEfeito;
        this.materialGlow = new MaterialGlow(material);
    }

    public void mudarMaterial(MaterialGlow materialGlow)
    {
        this.materialGlow = materialGlow;
    }

    public void ligarGlowSucesso()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(ArcoIrisEfeito.greenHdr);
    }

    public void ligarGlowFail()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(ArcoIrisEfeito.redHdr);
    }

    public void ligarGlowLuz()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(ArcoIrisEfeito.yellowHdr);
    }

    public void desligarGlow()
    {
        goEfeito.SetActive(false);
    }          
}
