using UnityEngine;

public class GlowEfeito 
{
    

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
