using UnityEngine;

public class EfeitoColetado 
{    
    private Vector3 posOriginalEfeito;
    private ParticleSystem efeitoColetado;        

    public EfeitoColetado(ParticleSystem efeitoColetado)
    {
        this.efeitoColetado      = efeitoColetado;
        posOriginalEfeito = this.efeitoColetado.transform.position; 
        this.efeitoColetado.Stop();
    }

    public void acionarEfeito(Vector3 posicao)
    {
        efeitoColetado.transform.position = new Vector3(posicao.x, posOriginalEfeito.y, posOriginalEfeito.z);
        efeitoColetado.Play();
    }    
}
