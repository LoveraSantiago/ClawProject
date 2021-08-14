using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AsaDto 
{
    [SerializeField] private int layer;
    [SerializeField] private float gravidadeNeg;
    [SerializeField] private float offset;
    [SerializeField] private float haltura;
    [SerializeField] private float delayFinalizar;
    [SerializeField] private GameObject asaGo;

    public int Layer { get { return layer; } }
    public float GravidadeNeg { get { return gravidadeNeg; } }
    public float Offset { get { return offset; } }
    public float Haltura { get { return haltura; } }
    public float DelayFinalizar { get { return delayFinalizar; } }
    public GameObject AsaGo { get { return asaGo; } }
}
