using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class TeleporteDto 
{
    [SerializeField] private float velocidadeTeleporte;
    [SerializeField] private float velocidadeCoringa;
    [SerializeField] private float delayFinal;
    [Space(3)]
    [SerializeField] private CorEfeitoTeleporteDto corEfeitoIgual;
    [SerializeField] private CorEfeitoTeleporteDto corEfeitoTeleporte;
    [SerializeField] private CorEfeitoTeleporteDto corEfeitoCoringa;
    [Space(3)]
    [SerializeField] private EfeitoParticulasTeleporteDto efeitoTeleporte1;
    [SerializeField] private EfeitoParticulasTeleporteDto efeitoTeleporte2;

    public float VelocidadeTeleporte { get { return velocidadeTeleporte; } }
    public float VelocidadeCoringa { get { return velocidadeCoringa; } }
    public float DelayFinal { get { return delayFinal; } }

    public CorEfeitoTeleporteDto CorEfeitoIgual { get { return corEfeitoIgual; } }
    public CorEfeitoTeleporteDto CorEfeitoTeleporte { get { return corEfeitoTeleporte; } }
    public CorEfeitoTeleporteDto CorEfeitoCoringa { get { return corEfeitoCoringa; } }

    public EfeitoParticulasTeleporteDto EfeitoTeleporte1 { get { return efeitoTeleporte1; } }
    public EfeitoParticulasTeleporteDto EfeitoTeleporte2 { get { return efeitoTeleporte2; } }
}
