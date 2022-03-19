using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CorpoGarraDto 
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform centroDaGarra;
    [SerializeField] private Transform pincaEsquerda;
    [SerializeField] private Transform pincaDireita;
    [SerializeField] private GameObject colisor;
    [SerializeField] private Animator animator;

    public Rigidbody2D RigidBody { get { return rigidBody; } }

    public Transform CentroDaGarra { get { return centroDaGarra; } }
    public Transform PincaEsquerda { get { return pincaEsquerda; } }
    public Transform PincaDireita { get { return pincaDireita; } }
    public GameObject Colisor { get { return colisor; } }
    public Animator Animator { get { return animator; } }
}
