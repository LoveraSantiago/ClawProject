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
    [SerializeField] float halturaExplosao;
    [SerializeField] float delayPosExplosao;
    [Space(3)]
    [SerializeField] private CameraShakeDto cameraShakeDto;
    [Space(3)]
    [SerializeField] private GameObject missilGo;
    [Space(3)]
    [SerializeField] private Sprite spriteMissil;
    [SerializeField] private PathMissilDto pathMissilDto;
    [SerializeField] private ParticleSystem efeitoExplosao;

    public float AngGarra { get { return angGarra; } }
    public float HalturaPos { get { return halturaPos; } }
    public float Velocidade { get { return velocidade; } }
    public float AnguloHit { get { return anguloHit; } }
    public float VelocidadeHit { get { return velocidadeHit; } }
    public float HalturaExplosao { get { return halturaExplosao; } }
    public float DelayPosExplosao { get { return delayPosExplosao; } }

    public CameraShakeDto CameraShakeDto { get { return cameraShakeDto; } }
    public GameObject MissilGo { get { return missilGo; } }
    public Sprite SpriteMissil { get { return spriteMissil; } }
    public PathMissilDto PathMissilDto { get { return pathMissilDto; } }
    public ParticleSystem EfeitoExplosao { get { return efeitoExplosao; } }
}
