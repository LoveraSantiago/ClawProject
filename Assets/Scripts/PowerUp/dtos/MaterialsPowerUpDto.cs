using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaterialsPowerUpDto 
{
    [SerializeField] private Material matExplosivos;
    [SerializeField] private Material matMecanimso;
    [SerializeField] private Material matImpulso;
    [SerializeField] private Material matLevitacao;
    [SerializeField] private Material matTransmutacao;

    public Material MatExplosivos { get { return matExplosivos; } }
    public Material MatMecanismo { get { return matMecanimso; } }
    public Material MatImpulso { get { return matImpulso; } }
    public Material MatLevitacao { get { return matLevitacao; } }
    public Material MatTransmutacao { get { return matTransmutacao; } }
}
