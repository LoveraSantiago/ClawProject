using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TeleporteDto 
{
    [SerializeField] private float velocidadeTeleporte;
    [SerializeField] private float velocidadeCoringa;
    [SerializeField] private float delayFinal;
    [Space(3)]
    [SerializeField] private ParticleSystem efeitoTeleporte1;
    [SerializeField] private ParticleSystem efeitoTeleporte2;

    public float VelocidadeTeleporte { get { return velocidadeTeleporte; } }
    public float VelocidadeCoringa { get { return velocidadeCoringa; } }
    public float DelayFinal { get { return delayFinal; } }

    public ParticleSystem EfeitoTeleporte1 { get { return efeitoTeleporte1; } }
    public ParticleSystem EfeitoTeleporte2 { get { return efeitoTeleporte2; } }
}
