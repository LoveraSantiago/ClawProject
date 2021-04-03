using UnityEngine;

public class InformacoesColetado
{    
    public int score { get; private set; }

    public Sprite sprite { get; private set; }
    public bool resetDisplay { get; private set; }

    public void addInfosDisplayScore(int score)
    {
        this.score = score;
    }

    public void addInfosDisplayColetados(Sprite sprite, bool resetDisplay)
    {
        this.sprite = sprite;
        this.resetDisplay = resetDisplay;
    }
}
