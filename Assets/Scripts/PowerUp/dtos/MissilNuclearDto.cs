using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MissilNuclearDto 
{
    [SerializeField] float angGarra;
    [SerializeField] float halturaPos;
    [SerializeField] float delayInicial;
    [SerializeField] float delayExplosao;
    [SerializeField] float delayFinal;
    [SerializeField] private GameObject missilNuclearGo;

    public float AngGarra { get { return angGarra; } }
    public float HalturaPos { get { return halturaPos; } }
    public float DelayInicial { get { return delayInicial; } }
    public float DelayExplosao { get { return delayExplosao; } }
    public float DelayFinal { get { return delayFinal; } }
    public GameObject MissilNuclearGo { get { return missilNuclearGo; } }
}
