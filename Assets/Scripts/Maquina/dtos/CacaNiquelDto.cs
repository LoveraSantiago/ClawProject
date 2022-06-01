using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CacaNiquelDto 
{
    [SerializeField] private Sprite sprVazio;
    [SerializeField] private Sprite sprMoeda;
    [Space(3)]
    [SerializeField] private Color corSucesso;
    [SerializeField] private Color corFalha;
    [SerializeField] private Color corMeio;

    public Sprite SprVazio { get { return sprVazio; } }
    public Sprite SprMoeda { get { return sprMoeda; } }

    public Color CorSucesso { get { return corSucesso; } }
    public Color CorFalha { get { return corFalha; } }
    public Color CorMeio { get { return corMeio; } }
}
