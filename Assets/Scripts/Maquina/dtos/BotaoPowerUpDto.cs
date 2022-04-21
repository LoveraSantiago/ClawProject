using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDto 
{
    [SerializeField] private SpriteRenderer sprAreaExterna;      
    [SerializeField] private SpriteRenderer sprEfeito;    

    public GameObject GoParent { get { return sprAreaExterna.transform.parent.gameObject; } }
    

    public SpriteRenderer SprEfeito { get { return sprEfeito; } }    
}
