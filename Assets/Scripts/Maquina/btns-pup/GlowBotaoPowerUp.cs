using UnityEngine;

public class GlowBotaoPowerUp 
{
    private static MaterialGlow materialGlowGeral;
    private static MaterialGlow materialGlowIndividual;

    private SpriteRenderer sprEfeito;
    private GlowEfeito glowEfeito;

    public GlowBotaoPowerUp(SpriteRenderer sprEfeito)
    {
        this.sprEfeito = sprEfeito;
        glowEfeito = new GlowEfeito(sprEfeito.gameObject, materialGlowGeral);
    }

    public void ligarGlow()
    {
        if(glowEfeito.materialGlow == materialGlowIndividual)
        {
            glowEfeito.ligarGlowLuz();
        }
        else
        {
            glowEfeito.ligarGlowSucesso();
        }
    }

    public void desligarGlow()
    {
        glowEfeito.desligarGlow();
    }

    public void passarCorDoMaterial(Color cor)
    {
        if(glowEfeito.materialGlow != materialGlowIndividual)
        {
            glowEfeito.materialGlow.setCorNoMaterial(cor);
        }
    }

    public void mudarParaMaterialIndividual()
    {
        mudarMaterial(materialGlowIndividual);
    }

    public void mudarParaMaterialArcoIris()
    {
        mudarMaterial(materialGlowGeral);
    }

    private void mudarMaterial(MaterialGlow materialGlow)
    {
        glowEfeito.mudarMaterial(materialGlow);
        sprEfeito.material = materialGlow.material;
    }

    public static void configurar(
        Material materialGeral, Material materialIndividual)
    {
        materialGlowGeral = new MaterialGlow(materialGeral);
        materialGlowIndividual = new MaterialGlow(materialIndividual);        
    }
}
