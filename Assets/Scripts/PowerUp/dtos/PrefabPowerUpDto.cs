using UnityEngine;
using System.Collections.Generic;

#pragma warning disable 0649
public class PrefabPowerUpDto : MonoBehaviour
{
    private static PrefabPowerUpDto instance;
    [SerializeField] private Sprite[] powerUpSprites;

    public Dictionary<string, Sprite> dicionarioDeSprites { get; private set; }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            montarDicionarioDeSprites(powerUpSprites);
        }
    }

    private void montarDicionarioDeSprites(Sprite[] arrayDeSpritesBotoes)
    {
        dicionarioDeSprites = new Dictionary<string, Sprite>();
        for (int contador = 0; contador < arrayDeSpritesBotoes.Length; contador++)
        {
            Sprite spriteIt = arrayDeSpritesBotoes[contador];
            dicionarioDeSprites.Add(spriteIt.name, spriteIt);
        }
    }

    public PrefabPowerUpDto getInstance()
    {
        return instance;
    }
}
