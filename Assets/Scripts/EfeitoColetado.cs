using UnityEngine;

public class EfeitoColetado : ConsumidorDeEvento<InformacoesColetado>
{
    private GameObject parentParticulas;
    private ParticleSystem particulas;

    public EfeitoColetado(GameObject parentParticulas)
    {
        this.parentParticulas = parentParticulas;
        particulas = parentParticulas.GetComponent<ParticleSystem>();
        particulas.Stop();
    }

    private void playEfeitoColetado(Vector3 posicao)
    {
        float posX = posicao.x;
        float posY = parentParticulas.transform.position.y;
        float posZ = parentParticulas.transform.position.z;
        parentParticulas.transform.position = new Vector3(posX, posY, posZ);
        particulas.Play();
    }

    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> INICIO
    public void consumirEvento(InformacoesColetado infoColetado)
    {
        playEfeitoColetado(infoColetado.posicao);
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEvento<InformacoesColetado> FIM

    public ConsumidorDeEvento<InformacoesColetado> getEfeitoConsumidorInfoColetado()
    {
        return this;
    }
}
