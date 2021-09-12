using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MinaDto 
{
    [SerializeField] private float haltura;
    [SerializeField] private float halturaExplosao;
    [Space(3)]
    [SerializeField] private float delayInicial;
    [SerializeField] private float delayExplosao;
    [SerializeField] private float delayPosExplosao;
    [Space(3)]
    [SerializeField] private GameObject minaTerrestreGo;

    public float Haltura { get { return haltura; } }
    public float HalturaExplosao { get { return halturaExplosao; } }

    public float DelayInicial { get { return delayInicial; } }
    public float DelayExplosao { get { return delayExplosao; } }
    public float DelayPosExplosao { get { return delayPosExplosao; } }

    public GameObject MinaTerrestreGo { get { return minaTerrestreGo; } }
}
