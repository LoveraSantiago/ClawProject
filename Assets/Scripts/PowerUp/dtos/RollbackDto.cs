using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class RollbackDto 
{    
    [SerializeField] private float delayReset;
    [SerializeField] private ParticleSystem efeitoChoque;
    
    public float DelayReset { get { return delayReset; } }
    public ParticleSystem EfeitoChoque { get { return efeitoChoque; } }


}
