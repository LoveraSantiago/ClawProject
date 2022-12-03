using UnityEngine;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class TutorialDto 
{
    [SerializeField] private float delayFimTutorialSucesso;
    [SerializeField] private float delayFimTutorialExpirado;
    [Space(3)]
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshPro lblTexto;

    public float DelayFimTutorialSucesso { get { return delayFimTutorialSucesso; } }
    public float DelayFimTutorialExpirado { get { return delayFimTutorialExpirado; } }

    public Animator Animator{ get { return animator; } }
    public GameObject GoTutorial { get { return animator.gameObject; } }
    public TextMeshPro LblTexto { get { return lblTexto; } }
}
