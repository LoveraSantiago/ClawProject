using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class EfeitoParticulasTeleporteDto 
{
    [SerializeField] private ParticleSystem efeitoTeleportePrincipal;
    [SerializeField] private ParticleSystem efeitoTeleporteBaixo;

    public ParticleSystem EfeitoTeleportePrincipal { get { return efeitoTeleportePrincipal; } }
    public ParticleSystem EfeitoTeleporteBaixo { get { return efeitoTeleporteBaixo; } }
}
