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

    public void ligarGlowSucesso()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(Color.green);
    }

    public void ligarGlowFail()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(Color.red);
    }

    public void ligarGlowLuz()
    {
        goEfeito.SetActive(true);
        materialGlow.setCorNoMaterial(Color.yellow);
    }

    public void desligarGlow()
    {
        goEfeito.SetActive(false);
    }      
}
