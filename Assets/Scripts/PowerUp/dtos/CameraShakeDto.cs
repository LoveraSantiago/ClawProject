using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CameraShakeDto 
{
    [SerializeField] private float amplitude;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float ganhoFreq;
    [SerializeField] private float duracao;

    public float Amplitude { get { return amplitude; } }
    public Vector3 Offset { get { return offset; } }
    public float GanhoFreq { get { return ganhoFreq; } }
    public float Duracao { get { return duracao; } }
}
