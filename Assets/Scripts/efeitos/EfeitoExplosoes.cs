using UnityEngine;

public class EfeitoExplosoes 
{
    public void ligar(ParticleSystem particleSystem, Vector3 posicao)
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
