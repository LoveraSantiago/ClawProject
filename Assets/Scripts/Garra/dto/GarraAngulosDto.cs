using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class GarraAngulosDto 
{
    [SerializeField] private float idleMin;
    [SerializeField] private float idleMax;

    public float IdleMin { get { return idleMin; } }
    public float IdleMax { get { return idleMax; } }
}
