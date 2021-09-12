using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MinaDto 
{
    [SerializeField] private float haltura;
    [SerializeField] private float delayExplosao;
    [SerializeField] private float delayPosExplosao;
    [SerializeField] private float halturaExplosao;
    [SerializeField] private GameObject minaTerrestreGo;

    public float Haltura { get { return haltura; } }
    public float DelayExplosao { get { return delayExplosao; } }
    public float DelayPosExplosao { get { return delayPosExplosao; } }
    public float HalturaExplosao { get { return halturaExplosao; } }

    public GameObject MinaTerrestreGo { get { return minaTerrestreGo; } }
}
