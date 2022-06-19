using UnityEngine;

public class CardPupSelecionadoDto 
{
    public Vector3 posicaoCard { get; private set; }
    public PowerUpEntidade powerUpEntidage { get; private set; }

    public CardPupSelecionadoDto(Vector3 posicaoCard, PowerUpEntidade powerUpEntidage)
    {
        this.posicaoCard = posicaoCard;
        this.powerUpEntidage = powerUpEntidage;
    }
}
