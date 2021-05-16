using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SingleDisplayColetadoDto
{
    [SerializeField] private SpriteRenderer sprRendererDentro;
    [Space(2)]
    [SerializeField] private GameObject goColetado;
    [SerializeField] private SpriteRenderer sprRendererColetado;

    public SpriteRenderer SprRendererDentro { get { return sprRendererDentro; } }

    public GameObject GoColetado { get { return goColetado; } }
    public SpriteRenderer SprRendererColetado { get { return sprRendererColetado; } }
}