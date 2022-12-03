using UnityEngine;

public class EfeitoColetado 
{   
    private ParticleSystem efeitoColetado;        

    public EfeitoColetado(ParticleSystem efeitoColetado)
    {
        this.efeitoColetado = efeitoColetado;    
        this.efeitoColetado.Stop();
    }

    public void acionarEfeito(Vector3 posicao)
    {
        float posY = efeitoColetado.transform.position.y;
        float posZ = efeitoColetado.transform.position.z;
        efeitoColetado.transform.position = new Vector3(posicao.x, posY, posZ);
        efeitoColetado.Play();
    }    
}
