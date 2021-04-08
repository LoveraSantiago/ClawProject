using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ParticulasDto 
{
    [SerializeField] private float velocidadeMovimentacao;
    [SerializeField] private Transform destinoParticulas;
    [SerializeField] private GameObject parentParticulas;
    [SerializeField] private GameObject seguidoraParticulas;

    public float VelocidadeMovimentacao { get { return velocidadeMovimentacao; } }
    public Transform DestinoParticulas { get { return destinoParticulas; } }
    public GameObject ParentParticulas { get { return parentParticulas; } }
    public GameObject SeguidoraParticulas { get { return seguidoraParticulas; } }
}
