using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PowerUpPrefabDto 
{
    [SerializeField] private int indice;
    [SerializeField] private Sprite sprGO;
    [SerializeField] private Sprite sprCard;

    public int Indice { get { return indice; } }
    public Sprite SprGO { get { return sprGO; } }
    public Sprite SprCard { get { return sprCard; } }
}
