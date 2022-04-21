using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class SpritesTampaBtnPupDto 
{
    [SerializeField] private Sprite tampaNormal;
    [SerializeField] private Sprite tampaPressionada;
    [SerializeField] private Sprite tampaSerrilhada;

    public Sprite TampaNormal { get { return tampaNormal; } }
    public Sprite TampaPressionada { get { return tampaPressionada; } }
    public Sprite TampaSerrilhada { get { return tampaSerrilhada; } }
}
