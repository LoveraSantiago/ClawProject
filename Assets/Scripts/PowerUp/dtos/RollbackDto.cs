using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class RollbackDto 
{    
    [SerializeField] private float delayReset;
    [SerializeField] private CorHdrEfeitoDto corEfeitoRollback;
    [SerializeField] private CorHdrEfeitoDto corEfeitoDescarte;
    [SerializeField] private ParticleSystem efeitoChoque;
    [SerializeField] private Renderer renderer;
    
    public float DelayReset { get { return delayReset; } }
    public CorHdrEfeitoDto CorEfeitoRollback { get { return corEfeitoRollback; } }
    public CorHdrEfeitoDto CorEfeitoDescarte { get { return corEfeitoDescarte; } }
    public ParticleSystem EfeitoChoque { get { return efeitoChoque; } }

    public Renderer Renderer { get { return renderer; } }

}
