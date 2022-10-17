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

    public bool isSpritesIguais(Sprite spr1, Sprite spr2, Sprite spr3)
    {
        return sprites[0] == spr1 && sprites[1] == spr2 && sprites[2] == spr3;
    }
}
