using UnityEngine;

public class GlowBotaoPowerUp 
{
    private bool isEfeitoIndividual;

    private GlowEfeito glowEfeito;
    private SpriteRenderer sprEfeito;

    public GlowBotaoPowerUp(SpriteRenderer sprEfeito)
    {
        this.sprEfeito = sprEfeito;

        MaterialGlow materialGlow = new MaterialGlow(sprEfeito.material);
        glowEfeito = new GlowEfeito(sprEfeito.gameObject, materialGlow);
    }

    public void ligarGlow()
    {
        glowEfeito.ligarGlowLuz();
    }

    public void ligarPeloEstadoGlow()
    {
        if(!isEfeitoIndividual)
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
        if(!isEfeitoIndividual)
        {
            glowEfeito.materialGlow.setCorNoMaterial(cor);
        }
        else
        {
            glowEfeito.materialGlow.setCorNoMaterial(Color.yellow);
        }
    }

    public void mudarParaMaterialIndividual()
    {
        isEfeitoIndividual = true;        
    }

    public void mudarParaMaterialArcoIris()
    {
        isEfeitoIndividual = false;        
    }

    private void mudarMaterial(MaterialGlow materialGlow)
    {
        glowEfeito.mudarMaterial(materialGlow);
        sprEfeito.material = materialGlow.material;
    }   
}
