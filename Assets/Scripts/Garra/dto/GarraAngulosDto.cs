using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GarraAngulosDto 
{
    [SerializeField] private float idleMin;
    [SerializeField] private float idleMax;
    [Space(3)]
    [SerializeField] private float abertura;
    [SerializeField] private float fechamento;

    public float IdleMin { get { return idleMin; } }
    public float IdleMax { get { return idleMax; } }

    public float Abertura { get { return abertura; } }
    public float Fechamento { get { return fechamento; } }

}
