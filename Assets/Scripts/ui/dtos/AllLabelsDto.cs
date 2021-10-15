using TMPro;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AllLabelsDto 
    //RENOMEAR
    //RENOMEAR
    //RENOMEAR
    //RENOMEAR
    //RENOMEAR
    //RENOMEAR
    //RENOMEAR
    //RENOMEAR
    //RENOMEAR
{
    [SerializeField] private TextMeshProUGUI lblPup;
    [SerializeField] private TextMeshProUGUI lblTipo;
    [SerializeField] private TextMeshProUGUI lblQtd;
    [SerializeField] private TextMeshProUGUI lblPreco;
    [SerializeField] private TextMeshProUGUI lblDescCurta;
    [SerializeField] private TextMeshProUGUI lblExplicacao;

    public TextMeshProUGUI LblPup { get { return lblPup; } }
    public TextMeshProUGUI LblTipo { get { return lblTipo; } }
    public TextMeshProUGUI LblQtd { get { return lblQtd; } }
    public TextMeshProUGUI LblPreco { get { return lblPreco; } }
    public TextMeshProUGUI LblDescCurta { get { return lblDescCurta; } }
    public TextMeshProUGUI LblExplicacao { get { return lblExplicacao; } }
}
