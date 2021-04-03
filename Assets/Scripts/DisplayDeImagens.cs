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
        if(indiceEspaco + 1 >= 3)
        {
            indiceEspaco = 0;
        }
        else
        {
            indiceEspaco++;
        }
    }

    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<Sprite> INICIO
    //ACIONADO COMO SEGUNDO STEP PELO PIPELINE DE COLETAVEL COLETADO
    //RECEBENDO O SPRITE DO COLETADO
    public void consumirEvento(Sprite spriteColetado)
    {
        adicionarSpriteAoDisplay(spriteColetado);
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<Sprite> FIM

    public ConsumidorDeEvento<Sprite> getConsumidorDeColetado()
    {
        return this;
    }
}
