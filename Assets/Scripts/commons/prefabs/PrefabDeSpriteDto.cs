using UnityEngine;
using System.Collections.Generic;

#pragma warning disable 0649
public class PrefabDeSpriteDto : MonoBehaviour
{   
    [SerializeField] private Sprite[] sprites;

    private bool inicializado;
    private Dictionary<string, Sprite> dicionarioDeSprites;

    private void Start()
    {
        inicializarDicionario();
    }

    public Dictionary<string, Sprite> getDicionarioDeSprites()
    {
        inicializarDicionario();
        return dicionarioDeSprites;
    }

    private void inicializarDicionario()
    {
        if (!inicializado)
        {            
            montarDicionarioDeSprites(sprites);
        }
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
}
