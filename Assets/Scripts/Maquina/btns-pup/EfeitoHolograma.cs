using UnityEngine;

public class EfeitoHolograma 
{
    private GameObject goEfeitoHolograma;

    public EfeitoHolograma(GameObject goEfeitoHolograma)
    {
        this.goEfeitoHolograma = goEfeitoHolograma;
    }

    public void ligar(Vector3 posicao, Quaternion rotacao)
    {
        goEfeitoHolograma.transform.position = posicao;
        goEfeitoHolograma.transform.rotation = rotacao;
        goEfeitoHolograma.SetActive(true);
    }

    public void desligar()
    {
        goEfeitoHolograma.SetActive(false);
    }
}
