using TMPro;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AllLabelsDto 
{
    [SerializeField] private TextMeshProUGUI lblPup;
    [SerializeField] private TextMeshProUGUI lblDescCurta;
    [SerializeField] private TextMeshProUGUI lblQtd;
    [SerializeField] private TextMeshProUGUI lblExplicacao;

    public TextMeshProUGUI LblPup { get { return lblPup; } }
    public TextMeshProUGUI LblDescCurta { get { return lblDescCurta; } }
    public TextMeshProUGUI LblQtd { get { return lblQtd; } }
    public TextMeshProUGUI LblExplicacao { get { return lblExplicacao; } }
}
