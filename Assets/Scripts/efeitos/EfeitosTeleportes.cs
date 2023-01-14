using UnityEngine;

public class EfeitosTeleportes 
{
    public void ligar(EfeitoParticulasTeleporteDto efeitoParticulasTeleporteDto, Vector3 posicao)
    {
        efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.gameObject.SetActive(true);
        efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.transform.position = posicao;
        efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.Play();
    }

    public void desligar(EfeitoParticulasTeleporteDto efeitoParticulasTeleporteDto)
    {
        efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.gameObject.SetActive(false);
    }
}
