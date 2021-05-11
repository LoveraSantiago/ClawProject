using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CaboGarraDto 
{
    [SerializeField] private Transform transfInicioCabo;
    [SerializeField] private LineRenderer lineRenderer;

    public Transform TransfInicioCabo { get { return transfInicioCabo; }}
    public LineRenderer LineRenderer { get { return lineRenderer;  }}
}
