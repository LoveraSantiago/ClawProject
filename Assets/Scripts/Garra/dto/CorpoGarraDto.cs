using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CorpoGarraDto 
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform centroDaGarra;
    [Space(3)]
    [SerializeField] private SpriteRenderer sprRendererBaseCorpo;
    [SerializeField] private SpriteRenderer sprRendererSimbolo;
    [Space(3)]
    [SerializeField] private SpriteRenderer sprRendererPincaEsquerda;
    [SerializeField] private SpriteRenderer sprRendererPincaDireita;    
    [Space(3)]
    [SerializeField] private GameObject colisor;
    [SerializeField] private Animator animator;

    public Rigidbody2D RigidBody { get { return rigidBody; } }

    public Transform CentroDaGarra { get { return centroDaGarra; } }

    public SpriteRenderer SprRendererPincaEsquerda { get { return sprRendererPincaEsquerda; } }
    public SpriteRenderer SprRendererPincaDireita { get { return sprRendererPincaDireita; } }
    public Transform TransformPincaEsquerda { get { return sprRendererPincaEsquerda.transform; } }
    public Transform TransformPincaDireita { get { return sprRendererPincaDireita.transform; } }

    public GameObject Colisor { get { return colisor; } }
    public Animator Animator { get { return animator; } }

    public SpriteRenderer SprRendererBaseCorpo { get { return sprRendererBaseCorpo; } }
    public SpriteRenderer SprRendererSimbolo { get { return sprRendererSimbolo; } }
}
