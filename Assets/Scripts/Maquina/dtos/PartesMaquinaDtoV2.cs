using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PartesMaquinaDtoV2 
{
    [SerializeField] private SpriteRenderer placaFrente;
    [SerializeField] private SpriteRenderer baseChao;
    [Space(3)]
    [SerializeField] private SpriteRenderer spriteRendererBarra;
    [SerializeField] private SpriteRenderer spriteRendererVigaEsquerda;
    [SerializeField] private SpriteRenderer spriteRendererVigaDireita;
    [SerializeField] private SpriteRenderer spriteRendererChao;
    [Space(3)]
    [SerializeField] private SpriteRenderer[] simbolosParteExterna;
    [SerializeField] private SpriteRenderer[] simbolosParteInterna;

    public SpriteRenderer PlacaFrente { get { return placaFrente; } }
    public SpriteRenderer BaseChao { get { return baseChao; } }

    public SpriteRenderer[] SimbolosParteExterna { get { return simbolosParteExterna; } }
    public SpriteRenderer[] SimbolosParteInterna { get { return simbolosParteInterna; } }

    public SpriteRenderer SpriteRendererBarra { get { return spriteRendererBarra; } }
    public SpriteRenderer SpriteRendererVigaEsquerda { get { return spriteRendererVigaEsquerda; } }
    public SpriteRenderer SpriteRendererVigaDireita  { get { return spriteRendererVigaDireita; } }
    public SpriteRenderer SpriteRendererChao { get { return spriteRendererChao; } }
}
