using UnityEngine;

public class CardPupSelecionadoDto 
{
    public int indice { get; private set; }
    public Vector3 posicaoCard { get; private set; }
    public PowerUpEntidade powerUpEntidade { get; private set; }

    public CardPupSelecionadoDto(
        int indice, Vector3 posicaoCard, PowerUpEntidade powerUpEntidage)
    {
        this.indice = indice;
        this.posicaoCard = posicaoCard;
        this.powerUpEntidade = powerUpEntidage;
    }
}
