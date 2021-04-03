using UnityEngine;

public class DisplayDeImagens : ConsumidorDeEvento<Sprite>
{
    private int indiceEspaco;
    private SpriteRenderer[] espacoImgs;

    public DisplayDeImagens(SpriteRenderer[] espacoImgs)
    {
        this.espacoImgs = espacoImgs;
    }

    private void adicionarSpriteAoDisplay(Sprite spriteColetado)
    {
        espacoImgs[indiceEspaco].sprite = spriteColetado;
        computarIndice();
    }

    private void computarIndice()
    {
        if(indiceEspaco + 1 >= 2)
        {
            indiceEspaco = 0;
        }
        else
        {
            indiceEspaco++;
        }
    }

    public ConsumidorDeEvento<Sprite> getConsumidorDeColetado()
    {
        return this;
    }

    public void consumirEvento(Sprite spriteColetado)
    {
        adicionarSpriteAoDisplay(spriteColetado);
    }
}
