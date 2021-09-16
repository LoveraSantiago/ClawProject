using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class RollbackDto 
{
    [SerializeField] private float delayInicial;
    [SerializeField] private float delayReset;
    [SerializeField] private float delayFinalizar;

    public float DelayInicial { get { return delayInicial; } }
    public float DelayReset { get { return delayReset; } }
    public float DelayFinalizar { get { return delayFinalizar; } }
}
