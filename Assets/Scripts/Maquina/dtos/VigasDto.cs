using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class VigasDto 
{
    [SerializeField] private SpriteRenderer vigaTrasEsquerda;
    [SerializeField] private SpriteRenderer vigaTrasDireita;    
    [SerializeField] private SpriteRenderer sprVigasTrasEsquerdaEfeito;    
    [SerializeField] private SpriteRenderer sprVigasTrasDireitaEfeito;

    public SpriteRenderer VigaTrasEsquerda { get { return vigaTrasEsquerda; } }
    public SpriteRenderer VigaTrasDireita { get { return vigaTrasDireita; } }
    public GameObject VigaTrasEsquerdaEfeito { get { return sprVigasTrasEsquerdaEfeito.gameObject; } }
    public SpriteRenderer SprVigasTrasEsquerdaEfeito { get { return sprVigasTrasEsquerdaEfeito; } }
    public GameObject VigaTrasDireitaEfeito { get { return sprVigasTrasDireitaEfeito.gameObject; } }
    public SpriteRenderer SprVigasTrasDireitaEfeito { get { return sprVigasTrasDireitaEfeito; } }
}
