using UnityEngine;

public class ComponenteEfeitosDaGarra : ComponentePincasDaGarrra
{
    public float alturaLocalEfeitoTrail { get; private set; }

    public ComponenteEfeitosDaGarra(GarraDto garraDto) 
        : base(garraDto)
    {
        alturaLocalEfeitoTrail = garraDto.EfeitoTrail.transform.localPosition.y;
    }

    public void ligarEfeitoTrailPCima()
    {
        //Debug.Log("ligarEfeitoTrailPCima");
        ligarEfeitoTrailAngulo(-0.4f, 180);
    }

    public void ligarEfeitoTrailPBaixo()
    {
        //Debug.Log("ligarEfeitoTrailPBaixo");
        ligarEfeitoTrailAngulo(0.8f, 0);
    }

    public void desligarEfeitoTrail()
    {
        getEfeitoTrail().Stop();
    }

    private void ligarEfeitoTrailAngulo(float incremento, float angulo)
    {
        ParticleSystem efeitoTrail = getEfeitoTrail();
        efeitoTrail.transform.rotation = Quaternion.Euler(0, 0, angulo);
        efeitoTrail.Play();

        Vector3 localPos = efeitoTrail.transform.localPosition;
        efeitoTrail.transform.localPosition = new Vector3(localPos.x, alturaLocalEfeitoTrail + incremento, localPos.z);
    }

    private ParticleSystem getEfeitoTrail()
    {
        return garraDto.EfeitoTrail;
    }
}
