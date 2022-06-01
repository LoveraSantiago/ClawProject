using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CaboGarraDto 
{
    [SerializeField] private float grossuraLinha;
    [SerializeField] private float tamanhoSegmento;    
    [SerializeField] private LineRenderer lineRenderer;

    public float GrossuraLinha { get { return grossuraLinha; } }
    public float TamanhoSegmento { get { return tamanhoSegmento; } }
    public Transform TransfInicioCabo { get { return lineRenderer.transform; }}
    public LineRenderer LineRenderer { get { return lineRenderer;  }}
}
