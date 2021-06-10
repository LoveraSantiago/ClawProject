using UnityEngine;

public class GlowEfeito 
{
    private static readonly string propMaterial = "_corGlow";
    private static Color singleColor;

    private GameObject goEfeito;
    private Material materialGlow;

    public GlowEfeito(GameObject goEfeito, Material materialGlow)
    {
        this.goEfeito = goEfeito;
        this.materialGlow = materialGlow;
    }

    public void ligarGlowSucesso()
    {
        goEfeito.SetActive(true);
        materialGlow.SetColor(propMaterial, Color.green);
    }

    public void ligarGlowFail()
    {
        goEfeito.SetActive(true);
        materialGlow.SetColor(propMaterial, Color.red);
    }

    public void ligarGlowLuz()
    {
        goEfeito.SetActive(true);
        materialGlow.SetColor(propMaterial, Color.yellow);
    }

    public void desligarGlow()
    {
        goEfeito.SetActive(false);
    }

    public void atualizarCorMaterial()
    {
        materialGlow.SetColor(propMaterial, singleColor);
    }

    public static void sortearCor()
    {
        singleColor = HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 0.5f, 1), 1, 1));
    }   
}
