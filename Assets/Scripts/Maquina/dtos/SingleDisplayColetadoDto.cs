using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleDisplayColetadoDto
{
    [SerializeField] private SpriteRenderer sprDisplay;
    [SerializeField] private SpriteRenderer sprRendererDentro;
    [SerializeField] private SpriteRenderer sprRendererDentroEfeito;
    [Space(2)]
    [SerializeField] private GameObject goColetado;
    [SerializeField] private SpriteRenderer sprRendererColetado;

    public SpriteRenderer SprDisplay { get { return sprDisplay; } }
    public SpriteRenderer SprRendererDentro { get { return sprRendererDentro; } }
    public SpriteRenderer SprRendererDentroEfeito { get { return sprRendererDentroEfeito; } }

    public GameObject GoColetado { get { return goColetado; } }
    public SpriteRenderer SprRendererColetado { get { return sprRendererColetado; } }
}