using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BombaDto
{
    [SerializeField] private float angGarra;
    [SerializeField] private float raioExplosao;
    [SerializeField] private float velocidadeHit;
    [SerializeField] private int anguloHit;
    [Space(3)]
    [SerializeField] private float delayInicial;
    [SerializeField] private float delayExplosao;
    [SerializeField] private float delayPosExplosao;
    [Space(3)]
    [SerializeField] private CameraShakeDto cameraShakeDto;
    [Space(3)]
    [SerializeField] private Sprite spriteBomba;
    [SerializeField] private GameObject bombaGo;

    public float AngGarra { get { return angGarra; } }

    public float DelayInicial { get { return delayInicial; } }
    public float DelayExplosao { get { return delayExplosao; } }
    public float DelayPosExplosao { get { return delayPosExplosao; } }

    public float RaioExplosao { get { return raioExplosao; } }
    public float VelocidadeHit { get { return velocidadeHit; } }
    public int AnguloHit { get { return anguloHit; } }

    public CameraShakeDto CameraShakeDto { get { return cameraShakeDto; } }
    public Sprite SpriteBomba { get { return spriteBomba; } }
    public GameObject BombaGo { get { return bombaGo; } }
}
