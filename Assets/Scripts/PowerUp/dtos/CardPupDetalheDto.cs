using TMPro;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CardPupDetalheDto 
{
    [SerializeField] private float velocidade;
    [SerializeField] private GameObject cardDetalhe;
    [SerializeField] private Material materialDetalhe;
    [SerializeField] private TextMeshProUGUI lblPreco;
    [SerializeField] private TextMeshProUGUI lblQtd;

    public float Velocidade { get { return velocidade; } }
    public GameObject CardDetalhe { get { return cardDetalhe; } }
    public Material MaterialDetalhe { get { return materialDetalhe; } }
    public TextMeshProUGUI LblPreco { get { return lblPreco; } }
    public TextMeshProUGUI LblQtd { get { return lblQtd; } }
}
