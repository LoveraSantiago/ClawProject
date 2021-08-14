using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BombaDto
{
    [SerializeField] float angGarra;
    [SerializeField] float delayInicial;
    [SerializeField] float delayExplosao;
    [SerializeField] float delayPosExplosao;
    [SerializeField] float raioExplosao;
    [SerializeField] float velocidadeHit;
    [SerializeField] int anguloHit;
    [SerializeField] private GameObject bombaGo;

    public float AngGarra { get { return angGarra; } }
    public float DelayInicial { get { return delayInicial; } }
    public float DelayExplosao { get { return delayExplosao; } }
    public float DelayPosExplosao { get { return delayPosExplosao; } }
    public float RaioExplosao { get { return raioExplosao; } }
    public float VelocidadeHit { get { return velocidadeHit; } }
    public int AnguloHit { get { return anguloHit; } }

    public GameObject BombaGo { get { return bombaGo; } }
}
