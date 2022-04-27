using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BotaoPowerUpDto 
{
    [SerializeField] private SpriteRenderer sprAreaExterna;          

    public GameObject GoParent { get { return sprAreaExterna.transform.parent.gameObject; } }
}
