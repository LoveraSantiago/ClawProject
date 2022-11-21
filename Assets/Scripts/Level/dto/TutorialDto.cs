using UnityEngine;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class TutorialDto 
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform transformMao;
    [SerializeField] private Transform transformPonto;   
    [SerializeField] private TextMeshPro lblTexto;

    public Animator Animator{ get { return animator; } }
    public GameObject GoTutorial { get { return animator.gameObject; } }
    public Transform TranformGoTutorial { get { return animator.gameObject.transform; } }
    public Transform TransformMao { get { return transformMao; } }
    public Transform TransformPonto { get { return transformPonto; } }
    public Transform TransformText { get { return lblTexto.gameObject.transform; } }
    public TextMeshPro LblTexto { get { return lblTexto; } }
}
