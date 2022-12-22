using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class EfeitoMaterializeDto
{
    [SerializeField] private float delayDuracao;
    [SerializeField] private float velocidadeMaterializacao;
    [Space(3)]
    [SerializeField] private ParticleSystem efeitoSpawnParticulas;
    [SerializeField] private Material materialMaterialize;
    [SerializeField] private GameObject goGo;

    public float DelayDuracao { get { return delayDuracao; } }
    public float VelocidadeMaterializacao { get { return velocidadeMaterializacao; } }

    public ParticleSystem EfeitoSpawnParticulas { get { return efeitoSpawnParticulas; } }
    public Material MaterialMaterialize { get { return materialMaterialize; } }
    public GameObject GoGo { get { return goGo; } }
}
