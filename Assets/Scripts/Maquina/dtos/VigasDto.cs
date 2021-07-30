using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class VigasDto 
{
    [SerializeField] private SpriteRenderer vigaTrasEsquerda;
    [SerializeField] private SpriteRenderer vigaTrasDireita;
    [SerializeField] private GameObject vigaTrasEsquerdaEfeito;
    [SerializeField] private GameObject vigaTrasDireitaEfeito;
    [SerializeField] private Material materialVigas;

    public SpriteRenderer VigaTrasEsquerda { get { return vigaTrasEsquerda; } }
    public SpriteRenderer VigaTrasDireita { get { return vigaTrasDireita; } }
    public GameObject VigaTrasEsquerdaEfeito { get { return vigaTrasEsquerdaEfeito; } }
    public GameObject VigaTrasDireitaEfeito { get { return vigaTrasDireitaEfeito; } }
    public Material MaterialVigas { get { return materialVigas; } }
}
