using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class VigasDto 
{
    [SerializeField] private SpriteRenderer vigaTrasDireita;    
    [SerializeField] private SpriteRenderer sprVigasTrasDireitaEfeito;

    public SpriteRenderer VigaTrasDireita { get { return vigaTrasDireita; } }
    public GameObject VigaTrasDireitaEfeito { get { return sprVigasTrasDireitaEfeito.gameObject; } }
    public SpriteRenderer SprVigasTrasDireitaEfeito { get { return sprVigasTrasDireitaEfeito; } }
}
