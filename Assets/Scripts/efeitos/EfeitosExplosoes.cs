using UnityEngine;

public class EfeitosExplosoes 
{
    public void explodir(ParticleSystem particleSystem, Vector3 posicao)
    {
        particleSystem.gameObject.SetActive(true);
        particleSystem.transform.position = posicao;
        particleSystem.Play();        
    }

    public void desligar(ParticleSystem particleSystem)
    {
        particleSystem.gameObject.SetActive(false);
    }
}
