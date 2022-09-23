using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class LevelMapDto 
{
    [SerializeField] private MapaEnum mapaEnum;
    [Space(2)]
    [SerializeField] private Sprite sprMapa;
    [Space(2)]
    [SerializeField] private Vector2[] posicoes = new Vector2[10];
    [Space(2)]
    [SerializeField] private ColetavelEntidadeDto[] coletaveisDto;

    public MapaEnum MapaEnum { get { return mapaEnum; } }
    public Sprite SprMapa { get { return sprMapa; } }
    public Vector2[] Posicoes { get { return posicoes; } }
    public ColetavelEntidadeDto[] ColetaveisDto { get { return coletaveisDto; } }
}
