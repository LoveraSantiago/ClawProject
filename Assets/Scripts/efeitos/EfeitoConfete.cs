using UnityEngine;

public class EfeitoConfete 
{
    public void dispararConfetes(ParticleSystem efeito, Vector3 posicao)
    {
        efeito.gameObject.transform.position = posicao;
        efeito.gameObject.SetActive(true);
        efeito.Play();
    }

    public void desligarConfetes(ParticleSystem efeito)
    {
        efeito.gameObject.SetActive(false);
    }
}
