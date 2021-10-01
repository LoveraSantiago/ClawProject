using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ColetavelTuboDeSaidaDto 
{
    [SerializeField] private Rigidbody2D rigidBodyColetavel;
    [SerializeField] private SpriteRenderer sprRendererColetavel;
    [Space(3)]
    [SerializeField] private Rigidbody2D rigidBodyTrail;
    [SerializeField] private ParticleSystem particulasTrail;

    public Rigidbody2D RigidBodyColetavel { get { return rigidBodyColetavel; } }
    public SpriteRenderer SprRendererColetavel { get { return sprRendererColetavel; } }

    public Rigidbody2D RigidBodyTrail { get { return rigidBodyTrail; } }
    public ParticleSystem ParticulasTrail { get { return particulasTrail; } }
}
