using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TeleporteDto 
{
    [SerializeField] private float velocidadeTeleporte;
    [SerializeField] private float velocidadeCoringa;
    [SerializeField] private float delayFinal;
    [SerializeField] private ParticleSystem efeitoTeleporte;

    public float VelocidadeTeleporte { get { return velocidadeTeleporte; } }
    public float VelocidadeCoringa { get { return velocidadeCoringa; } }
    public float DelayFinal { get { return delayFinal; } }

    public ParticleSystem EfeitoTeleporte { get { return efeitoTeleporte; } }
}
