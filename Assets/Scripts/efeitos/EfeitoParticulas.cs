using UnityEngine;

public class EfeitoParticulas 
{
    public void explodir(ParticleSystem efeitoExplosao, Vector3 posicao)
    {
        efeitoExplosao.gameObject.SetActive(true);
        efeitoExplosao.transform.position = posicao;
        efeitoExplosao.Play();        
    }

    public void desligar(ParticleSystem efeitoExplosao)
    {
        efeitoExplosao.gameObject.SetActive(false);
    }
}
