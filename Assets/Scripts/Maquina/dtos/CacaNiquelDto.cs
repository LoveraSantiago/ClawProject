using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CacaNiquelDto 
{
    [SerializeField] private Sprite sprVazio;
    [SerializeField] private Sprite sprMoeda;

    public Sprite SprVazio { get { return sprVazio; } }
    public Sprite SprMoeda { get { return sprMoeda; } }
}
