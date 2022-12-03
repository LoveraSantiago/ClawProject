using UnityEngine;

public class EfeitoExplosao 
{
    public void explodir(ParticleSystem efeitoExplosao, Vector3 posicao)
    {
        efeitoExplosao.gameObject.SetActive(true);
        efeitoExplosao.transform.position = posicao;
        efeitoExplosao.Play();        
    }
}
