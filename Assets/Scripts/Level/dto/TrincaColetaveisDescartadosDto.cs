using UnityEngine;

public class TrincaColetaveisDescartadosDto
{
    public Sprite[] sprites { get; private set; }
    public float timeStamp { get; private set; }

    public TrincaColetaveisDescartadosDto(Sprite[] sprites, float timeStamp)
    {
        this.sprites = sprites;
        this.timeStamp = timeStamp;
    }
}
