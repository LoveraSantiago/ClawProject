using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PartesMaquinaDtoV2 
{
    [SerializeField] private SpriteRenderer placaFrente;
    [SerializeField] private SpriteRenderer baseChao;
    [Space(3)]
    [SerializeField] private SpriteRenderer sprRendererBarra;
    [SerializeField] private SpriteRenderer sprRendererVigaEsquerda;
    [SerializeField] private SpriteRenderer sprRendererVigaDireita;
    [SerializeField] private SpriteRenderer sprRendererChao;    
    [Space(3)]
    [SerializeField] private SpriteRenderer[] simbolosParteExterna;
    [SerializeField] private SpriteRenderer[] simbolosParteInterna;

    public SpriteRenderer PlacaFrente { get { return placaFrente; } }
    public SpriteRenderer BaseChao { get { return baseChao; } }

    public SpriteRenderer[] SimbolosParteExterna { get { return simbolosParteExterna; } }
    public SpriteRenderer[] SimbolosParteInterna { get { return simbolosParteInterna; } }

    public SpriteRenderer SprRendererBarra { get { return sprRendererBarra; } }
    public SpriteRenderer SprRendererVigaEsquerda { get { return sprRendererVigaEsquerda; } }
    public SpriteRenderer SprRendererVigaDireita  { get { return sprRendererVigaDireita; } }
    public SpriteRenderer SprRendererChao { get { return sprRendererChao; } }
}
