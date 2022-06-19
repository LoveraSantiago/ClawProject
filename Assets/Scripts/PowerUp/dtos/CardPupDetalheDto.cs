using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CardPupDetalheDto 
{
    [SerializeField] private float velocidade;
    [SerializeField] private GameObject cardDetalhe;

    public float Velocidade { get { return velocidade; } }
    public GameObject CardDetalhe { get { return cardDetalhe; } }
}
