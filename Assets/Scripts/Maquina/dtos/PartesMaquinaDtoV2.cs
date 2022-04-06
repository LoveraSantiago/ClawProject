using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PartesMaquinaDtoV2 
{
    [SerializeField] private SpriteRenderer placaFrente;
    [SerializeField] private SpriteRenderer baseChao;
    [SerializeField] private SpriteRenderer[] simbolosParteExterna;
    [SerializeField] private SpriteRenderer[] simbolosParteInterna;

    public SpriteRenderer PlacaFrente { get { return placaFrente; } }
    public SpriteRenderer BaseChao { get { return baseChao; } }

    public SpriteRenderer[] SimbolosParteExterna { get { return simbolosParteExterna; } }
    public SpriteRenderer[] SimbolosParteInterna { get { return simbolosParteInterna; } }
}
