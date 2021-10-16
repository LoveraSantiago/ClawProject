using UnityEngine;

public class UiColetavelInfo 
{
    public Sprite sprite { get; private set; }
    public ColetavelEntidade coletavelEntidade { get; private set; }

    public UiColetavelInfo(ColetavelEntidade coletavelEntidade, Sprite sprite)
    {
        this.coletavelEntidade = coletavelEntidade;
        this.sprite = sprite;
    }
}
