using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class AsaDto 
{
    [SerializeField] private float gravidadeNeg;
    [SerializeField] private float offset;
    [SerializeField] private float haltura;
    [SerializeField] private float delayAsaAbrir;
    [SerializeField] private float delayFinalizar;
    [Space(3)]
    [SerializeField] private GameObject asaGo;    

    public float GravidadeNeg { get { return gravidadeNeg; } }
    public float Offset { get { return offset; } }
    public float Haltura { get { return haltura; } }
    public float DelayAsaAbrir { get { return delayAsaAbrir; } }
    public float DelayFinalizar { get { return delayFinalizar; } }

    public GameObject AsaGo { get { return asaGo; } }    
}
