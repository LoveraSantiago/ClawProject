using UnityEngine;

public class CardDetalhePup : AcaoCardPupDetalheMovimentado.ProdutorEvento,
                              AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    private Vector3 posOriginal;
    private Vector3 posDestino;
    private CardPupDetalheDto cardDetalheDto;

    private ProdutorDeEvento<bool> produtorDeEvento;

    public CardDetalhePup(CardPupDetalheDto cardDetalheDto)
    {
        this.cardDetalheDto = cardDetalheDto;
        posOriginal = cardDetalheDto.CardDetalhe.transform.position;
        posDestino = Vector3.zero;
        produtorDeEvento = new ProdutorDeEvento<bool>();
    }

    public void update()
    {
        if (deveMovimentar())
        {
            Vector3 result = Vector3.MoveTowards(cardDetalheDto.CardDetalhe.transform.position, posOriginal, cardDetalheDto.Velocidade * Time.deltaTime);
            cardDetalheDto.CardDetalhe.transform.position = result;
            float distancia = Vector3.Distance(cardDetalheDto.CardDetalhe.transform.position, posOriginal);
            if (distancia < 0.1f)
            {   
                cardDetalheDto.CardDetalhe.transform.position = posOriginal;
                posDestino = Vector3.zero;
                produtorDeEvento.produziuEvento(true);
            }
        }
    }

    public void movimentar(Vector3 posicaoInicial)
    {
        posDestino = posicaoInicial;
        cardDetalheDto.CardDetalhe.transform.position = posDestino;
        cardDetalheDto.CardDetalhe.SetActive(true);
    }

    private bool deveMovimentar()
    {
        return posDestino != Vector3.zero;
    }

    ProdutorDeEvento<bool> AcaoCardPupDetalheMovimentado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }

    void AcaoCardPowerUpSelecionado.ConsumidorEvento.consumirEvento(CardPupSelecionadoDto evento)
    {
        movimentar(evento.posicaoCard);

        PowerUpEntidade pupEntidade = evento.powerUpEntidade;
        cardDetalheDto.LblPreco.text = pupEntidade.preco;
        cardDetalheDto.LblQtd.text = PlayerPrefsPowerUp.recuperarQtdPup(pupEntidade.nome).ToString();

        MaterialTipoPowerUpDto materialPup = pupEntidade.getMaterial();
        Material materialDetalhe = cardDetalheDto.MaterialDetalhe;
        materialDetalhe.SetTexture("_imgCard", pupEntidade.sprCard.texture);
        materialDetalhe.SetColor("_corPrincipal", materialPup.CorPrincipal);
        materialDetalhe.SetColor("_corCirculo", materialPup.CorCirculo);
        materialDetalhe.SetColor("_corEscura", materialPup.CorEscura);
    }
}
