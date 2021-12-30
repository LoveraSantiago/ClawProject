using UnityEngine;

public class EfeitoHolograma 
{
    private GameObject goEfeitoHolograma;

    public EfeitoHolograma(GameObject goEfeitoHolograma)
    {
        this.goEfeitoHolograma = goEfeitoHolograma;
    }

    public void ligar(BotaoPowerUpDto btnDto)
    {
        Transform tranformParent = btnDto.GoParent.transform;
        Vector3 posicao = tranformParent.position;
        Quaternion rotacao = tranformParent.rotation;

        goEfeitoHolograma.transform.position = posicao;
        goEfeitoHolograma.transform.rotation = rotacao;
        goEfeitoHolograma.SetActive(true);
    }

    public void desligar()
    {
        goEfeitoHolograma.SetActive(false);
    }
}
