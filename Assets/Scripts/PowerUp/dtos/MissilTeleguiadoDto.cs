using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MissilTeleguiadoDto 
{
    [SerializeField] float angGarra;
    [SerializeField] float halturaPos;
    [SerializeField] float velocidade;
    [SerializeField] float anguloHit;
    [SerializeField] float velocidadeHit;
    [SerializeField] float delayFinalizar;
    [SerializeField] private GameObject missilGo;
    [Space(3)]
    [SerializeField] private PathMissilDto pathMissilDto;

    public float AngGarra { get { return angGarra; } }
    public float HalturaPos { get { return halturaPos; } }
    public float Velocidade { get { return velocidade; } }
    public float AnguloHit { get { return anguloHit; } }
    public float VelocidadeHit { get { return velocidadeHit; } }
    public float DelayFinalizar { get { return delayFinalizar; } }

    public GameObject MissilGo { get { return missilGo; } }
    public PathMissilDto PathMissilDto { get { return pathMissilDto; } }
}
