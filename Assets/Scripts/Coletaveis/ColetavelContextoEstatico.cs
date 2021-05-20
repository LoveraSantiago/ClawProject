using System.Collections.Generic;
using UnityEngine;

public class ColetavelContextoEstatico : MonoBehaviour
{
    public Nomeador nomeador { get; private set; }
    public GameObject mainTile { get; private set; }
    public Transform mainTileParent { get; private set; }
    public Dictionary<string, Sprite> dicionarioDeSprites { get; private set; }

    public void configurar(GameObject mainTile, Transform mainTileParent, List<Sprite> characters)
    {
        this.mainTile = mainTile;
        this.mainTileParent = mainTileParent;

        nomeador = new Nomeador();

        dicionarioDeSprites = new Dictionary<string, Sprite>();
        for (int contador = 0; contador < characters.Count; contador++)
        {
            Sprite spriteIt = characters[contador];
            dicionarioDeSprites.Add(spriteIt.name, spriteIt);
        }
    }
}
