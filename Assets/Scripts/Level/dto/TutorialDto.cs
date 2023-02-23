using UnityEngine;
using TMPro;

#pragma warning disable 0649
[System.Serializable]
public class TutorialDto 
{
    [SerializeField] private float delayFimTutorialSucesso;
    [SerializeField] private float delayFimTutorialExpirado;
    [Space(3)]
    [SerializeField] private Animator animatorOld;
    [SerializeField] private Animator animatorNew;
    [SerializeField] private TextMeshPro lblTexto;

    public float DelayFimTutorialSucesso { get { return delayFimTutorialSucesso; } }
    public float DelayFimTutorialExpirado { get { return delayFimTutorialExpirado; } }

    public Animator AnimatorOld{ get { return animatorOld; } }
    public Animator AnimatorNew{ get { return animatorNew; } }
    public GameObject GoTutorialNew { get { return animatorNew.gameObject; } }
    public GameObject GoTutorialOld { get { return animatorOld.gameObject; } }
    public TextMeshPro LblTexto { get { return lblTexto; } }
}
