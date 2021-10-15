using System.Collections.Generic;
using UnityEngine;

public class ColetavelContextoEstatico 
{
    public readonly int IDLE           = Animator.StringToHash("idle");
    public readonly int MIRAR_ON       = Animator.StringToHash("mirar-on");
    public readonly int MIRAR_SELECTED = Animator.StringToHash("mirar-selected");    

    public Nomeador nomeador { get; private set; }
    public GameObject mainTile { get; private set; }
    public Material mainMaterial { get; private set; }
    public Transform mainTileParent { get; private set; }
    public Dictionary<string, Sprite> dicionarioDeSprites { get; private set; }

    public void configurar(ColetaveisDto coletaveisDto)
    {
        mainTile = coletaveisDto.Tile;
        mainMaterial = mainTile.GetComponent<SpriteRenderer>().sharedMaterial;
        mainTileParent = coletaveisDto.BoardDto.StartBoard;

        nomeador = new Nomeador();

        PrefabDeSpriteDto prefabColetaveisDto = coletaveisDto.PrefabColetaveisDto.GetComponent<PrefabDeSpriteDto>();
        dicionarioDeSprites = prefabColetaveisDto.getDicionarioDeSprites();
    }
}
