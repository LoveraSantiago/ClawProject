using UnityEngine;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class LoadingDto 
{
    [SerializeField] private float delayAbrirModal;
    [SerializeField] private float delayFecharModal;
    [Space(3)]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject goCanvas;
    [SerializeField] private TextMeshProUGUI lblLoadingTexto;

    public float DelayAbrirModal { get { return delayAbrirModal; } }
    public float DelayFecharModal { get { return delayFecharModal; } }

    public Animator Animator { get { return animator; } }
    public GameObject GoCanvas { get { return goCanvas; } }
    public TextMeshProUGUI LblLoadingTexto { get { return lblLoadingTexto; } }
}
