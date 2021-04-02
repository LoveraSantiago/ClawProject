using UnityEngine;

public class DisplayDeImagens : ConsumidorDeEvento<GameObject>
{
    private int indiceEspaco;
    private SpriteRenderer[] espacoImgs;

    public DisplayDeImagens(SpriteRenderer[] espacoImgs)
    {
        this.espacoImgs = espacoImgs;
    }

    public ConsumidorDeEvento<GameObject> getConsumidorDeColetado()
    {
        return this;
    }

    public void consumirEvento(GameObject goColetado)
    {
        extrairSpriteParaODisplay(goColetado);
    }

    private void extrairSpriteParaODisplay(GameObject goColetado)
    {
        espacoImgs[indiceEspaco].sprite = goColetado.GetComponent<SpriteRenderer>().sprite;
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
}
