using TMPro;
using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class RelogioDto 
{
    [SerializeField] private TextMeshProUGUI lblHoras;
    [Space(5)]
    [SerializeField] private Transform transfSegundos;
    [SerializeField] private Transform transfMinutos;
    [SerializeField] private Transform transfHoras;

    public TextMeshProUGUI LblHoras { get { return lblHoras; } }

    public Transform TransfSegundos { get { return transfSegundos; } }
    public Transform TransfMinutos { get { return transfMinutos; } }
    public Transform TransfHoras { get { return transfHoras; } }
}
