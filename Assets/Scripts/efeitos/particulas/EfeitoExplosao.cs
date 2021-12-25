using UnityEngine;

public class EfeitoExplosao 
{
    private PowerUpDto powerUpDto;

    public EfeitoExplosao(PowerUpDto powerUpDto)
    {
        this.powerUpDto = powerUpDto;
    }

    public void explodir(Vector3 posicao)
    {
        powerUpDto.GoEfeitoExplosao.SetActive(true);
        powerUpDto.GoEfeitoExplosao.transform.position = posicao;
        powerUpDto.EfeitoExplosao.Play();
    }
}
