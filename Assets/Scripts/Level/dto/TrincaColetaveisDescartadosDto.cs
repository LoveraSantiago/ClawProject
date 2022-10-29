using UnityEngine;
using System.Collections.Generic;

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

    public bool isMesmosSprites()
    {
        return sprites[0] == sprites[1] && sprites[1] == sprites[2];
    }

    public static Dictionary<Sprite, int> descartadosToDictionary(List<TrincaColetaveisDescartadosDto> lista)
    {
        Dictionary<Sprite, int> dicionarioDescartados = new Dictionary<Sprite, int>();
        for (int contador = 0; contador < lista.Count; contador++)
        {
            Sprite[] sprites = lista[contador].sprites;
            for(int contadorSprites = 0; contadorSprites < sprites.Length; contadorSprites++)
            {
                Sprite spriteIt = sprites[contadorSprites];
                if(spriteIt != null)
                {
                    if (dicionarioDescartados.ContainsKey(spriteIt))
                    {
                        dicionarioDescartados[spriteIt] = dicionarioDescartados[spriteIt] + 1;
                    }
                    else
                    {
                        dicionarioDescartados.Add(spriteIt, 1);
                    }
                }
            }
        }
        return dicionarioDescartados;
    }
}
