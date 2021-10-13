using UnityEngine;

public class GarraEfeito 
{
    public float alturaLocalEfeitoTrail { get; private set; }
    private ParticleSystem efeitoTrail;

    public GarraEfeito(ParticleSystem efeitoTrail)
    {
        this.efeitoTrail = efeitoTrail;
        alturaLocalEfeitoTrail = efeitoTrail.transform.localPosition.y;
    }

    public void ligarTrailPCima()
    {
        ligarEfeitoTrailAngulo(-0.4f, 180);
    }

    public void ligarTrailPBaixo()
    {
        ligarEfeitoTrailAngulo(0.8f, 0);
    }

    private void ligarEfeitoTrailAngulo(float incremento, float angulo)
    {
        efeitoTrail.transform.rotation = Quaternion.Euler(0, 0, angulo);
        efeitoTrail.Play();

        Vector3 localPos = efeitoTrail.transform.localPosition;
        efeitoTrail.transform.localPosition = new Vector3(localPos.x, alturaLocalEfeitoTrail + incremento, localPos.z);
    }
}
