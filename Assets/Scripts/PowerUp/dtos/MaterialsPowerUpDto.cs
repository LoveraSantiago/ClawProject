using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaterialsPowerUpDto 
{
    [SerializeField] private MaterialTipoPowerUpDto matExplosivos;
    [Space(3)]
    [SerializeField] private MaterialTipoPowerUpDto matMecanimso;
    [Space(3)]
    [SerializeField] private MaterialTipoPowerUpDto matImpulso;
    [Space(3)]
    [SerializeField] private MaterialTipoPowerUpDto matLevitacao;
    [Space(3)]
    [SerializeField] private MaterialTipoPowerUpDto matTransmutacao;

    public MaterialTipoPowerUpDto MatExplosivos { get { return matExplosivos; } }
    public MaterialTipoPowerUpDto MatMecanismo { get { return matMecanimso; } }
    public MaterialTipoPowerUpDto MatImpulso { get { return matImpulso; } }
    public MaterialTipoPowerUpDto MatLevitacao { get { return matLevitacao; } }
    public MaterialTipoPowerUpDto MatTransmutacao { get { return matTransmutacao; } }
}
