using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AsaMiniDto 
{
    [SerializeField] private float gravidadeNeg;
    [SerializeField] private float offset;
    [SerializeField] private float incrementoHaltura;
    [Space(3)]
    [SerializeField] private GameObject asaMiniGo;

    public float GravidadeNeg { get { return gravidadeNeg; } }
    public float Offset { get { return offset; } }
    public float IncrementoHaltura { get { return incrementoHaltura; } }

    public GameObject AsaMiniGo { get { return asaMiniGo; } }
}
