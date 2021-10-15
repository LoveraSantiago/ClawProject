using UnityEngine;
using System.Collections.Generic;

#pragma warning disable 0649
public class PrefabDeSpriteDto : MonoBehaviour
{
    private static PrefabDeSpriteDto instance;
    [SerializeField] private Sprite[] sprites;

    public Dictionary<string, Sprite> dicionarioDeSprites { get; private set; }

    private void Start()
    {
        inicializarInstancia();
    }

    private void montarDicionarioDeSprites(Sprite[] arrayDeSprites)
    {
        dicionarioDeSprites = new Dictionary<string, Sprite>();
        for (int contador = 0; contador < arrayDeSprites.Length; contador++)
        {
            Sprite spriteIt = arrayDeSprites[contador];
            dicionarioDeSprites.Add(spriteIt.name, spriteIt);
        }
    }

    private void inicializarInstancia()
    {
        if (instance == null)
        {
            instance = this;
            montarDicionarioDeSprites(sprites);
        }
    }

    public PrefabDeSpriteDto getInstance()
    {
        inicializarInstancia();
        return instance;
    }
}
