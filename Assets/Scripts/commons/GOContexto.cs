using UnityEngine;

public class GOContexto 
{
    public Nomeador nomeador { get; private set; }
    public GameObject mainTile { get; private set; }
    public Material mainMaterial { get; private set; }
    public Transform mainTileParent { get; private set; }    

    public void configurar(ColetaveisDto coletaveisDto)
    {
        mainTile = coletaveisDto.Tile;
        mainMaterial = mainTile.GetComponent<SpriteRenderer>().sharedMaterial;
        mainTileParent = coletaveisDto.BoardDto.StartBoard;

        nomeador = new Nomeador();        
    }
}
