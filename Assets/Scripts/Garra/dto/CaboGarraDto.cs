using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CaboGarraDto 
{
    [SerializeField] private float grossuraLinha;
    [SerializeField] private float tamanhoSegmento;
    [SerializeField] private Transform transfInicioCabo;
    [SerializeField] private LineRenderer lineRenderer;

    public float GrossuraLinha { get { return grossuraLinha; } }
    public float TamanhoSegmento { get { return tamanhoSegmento; } }
    public Transform TransfInicioCabo { get { return transfInicioCabo; }}
    public LineRenderer LineRenderer { get { return lineRenderer;  }}
}
