using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MissilNuclearDto 
{
    [SerializeField] float angGarra;
    [SerializeField] float halturaPos;
    [Space(3)]
    [SerializeField] float delayInicial;
    [SerializeField] float delayExplosao;
    [SerializeField] float delayPosExplosao;
    [Space(3)]
    [SerializeField] private Sprite spriteMissilNuclear;
    [SerializeField] private GameObject missilNuclearGo;

    public float AngGarra { get { return angGarra; } }
    public float HalturaPos { get { return halturaPos; } }

    public float DelayInicial { get { return delayInicial; } }
    public float DelayExplosao { get { return delayExplosao; } }
    public float DelayPosExplosao { get { return delayPosExplosao; } }

    public Sprite SpriteMissilNuclear { get { return spriteMissilNuclear; } }
    public GameObject MissilNuclearGo { get { return missilNuclearGo; } }
}
