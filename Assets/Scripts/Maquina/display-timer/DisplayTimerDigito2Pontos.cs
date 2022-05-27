using UnityEngine;

public class DisplayTimerDigito2Pontos 
{
    private Color corOriginal;
    private Material material2Pontos;    
    private SpriteRenderer sprRenderer2Pontos;

    public DisplayTimerDigito2Pontos(SpriteRenderer sprRenderer2Pontos)
    {
        this.sprRenderer2Pontos = sprRenderer2Pontos;        
    } 

    public void configuradoPeloLevel(Material material2Pontos, Color corDigito)
    {
        this.material2Pontos = material2Pontos;
        MaterialHdr.setTexture(this.material2Pontos, sprRenderer2Pontos.sprite);       

        corOriginal = corDigito;        
        ligar();
    }

    public void estadoBlink(bool estadoBlink)
    {
        if (estadoBlink)
        {
            desligar();
        }
        else
        {
            ligar();            
        }
    }

    private void ligar()
    {
        setCor(Color.red);
        sprRenderer2Pontos.sharedMaterial = material2Pontos;        
    }

    public void desligar()
    {
        setCor(corOriginal);
        sprRenderer2Pontos.sharedMaterial = MaterialSprUnlitDefault.getMaterial();
    }

    private void setCor(Color cor)
    {
        sprRenderer2Pontos.color = cor;
    }    
}
