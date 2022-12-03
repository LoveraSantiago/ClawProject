using UnityEngine;

public class EfeitoExplosao 
{
    public void explodir(ParticleSystem efeitoExploao, Vector3 posicao)
    {
        efeitoExploao.gameObject.SetActive(true);
        efeitoExploao.transform.position = posicao;
        efeitoExploao.Play();        
    }
}
