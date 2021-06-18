using UnityEngine;

public class GlowEfeito 
{   
    private GameObject goEfeito;
    private MaterialGlow materialGlow;

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
