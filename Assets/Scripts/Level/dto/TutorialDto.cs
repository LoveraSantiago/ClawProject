using UnityEngine;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class TutorialDto 
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshPro lblTexto;

    public Animator Animator{ get { return animator; } }
    public GameObject GoTutorial { get { return animator.gameObject; } }
    public TextMeshPro LblTexto { get { return lblTexto; } }
}
