using UnityEngine;

public class EfeitosTeleportes 
{
    public void ligar(EfeitoParticulasTeleporteDto efeitoParticulasTeleporteDto, Color cor, Vector3 posicao)
    {
        GradientColorKey[] gradientColor = new GradientColorKey[]{
            new GradientColorKey(Color.white, 0.179f),
            new GradientColorKey(cor, 0.309f),
            new GradientColorKey(cor, 0.724f),
            new GradientColorKey(Color.white, 0.909f),
        };

        GradientAlphaKey[] gradientAlpha = new GradientAlphaKey[] {
            new GradientAlphaKey(0.81f, 0f),
            new GradientAlphaKey(0.91f, 1f),
        };

        Gradient gradient = new Gradient();
        gradient.SetKeys(gradientColor, gradientAlpha);

        ParticleSystem.ColorOverLifetimeModule col = efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.colorOverLifetime;
        col.color = gradient;

        col = efeitoParticulasTeleporteDto.EfeitoTeleporteBaixo.colorOverLifetime;
        col.color = gradient;

        efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.gameObject.SetActive(true);
        efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.transform.position = posicao;
        efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.Play();
    }

    public void desligar(EfeitoParticulasTeleporteDto efeitoParticulasTeleporteDto)
    {
        efeitoParticulasTeleporteDto.EfeitoTeleportePrincipal.gameObject.SetActive(false);
    }
}
