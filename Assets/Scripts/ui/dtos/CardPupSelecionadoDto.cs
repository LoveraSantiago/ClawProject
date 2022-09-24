using UnityEngine;

public class CardPupSelecionadoDto 
{
    public int indice { get; private set; }
    public Vector3 posicaoCard { get; private set; }
    public PowerUpEntidade powerUpEntidade { get; private set; }
    public bool restauracaoTela;

    public CardPupSelecionadoDto addIndice(int indice)
    {
        this.indice = indice;
        return this;
    }

    public CardPupSelecionadoDto addPosicaoCardSelecionado(Vector3 posicaoCard)
    {
        this.posicaoCard = posicaoCard;
        return this;
    }

    public CardPupSelecionadoDto addPupSelecionado(PowerUpEntidade pupEntidade)
    {
        this.powerUpEntidade = pupEntidade;
        return this;
    }

    public CardPupSelecionadoDto addRestauracaoTela(bool restauracao)
    {
        this.restauracaoTela = restauracao;
        return this;
    }
}
