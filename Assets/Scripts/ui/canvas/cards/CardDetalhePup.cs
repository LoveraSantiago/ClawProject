using UnityEngine;

public class CardDetalhePup : AcaoCardPupDetalheMovimentado.ProdutorEvento,
                              AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    private Vector3 posOriginal;
    private Vector3 posFinal;
    private Vector3 posInicial;
    private CardPupDetalheDto cardDetalheDto;

    private ProdutorDeEvento<bool> produtorDeEvento;

    public CardDetalhePup(CardPupDetalheDto cardDetalheDto)
    {
        this.cardDetalheDto = cardDetalheDto;
        posOriginal = cardDetalheDto.CardDetalhe.transform.position;
        posInicial = Vector3.zero;
        produtorDeEvento = new ProdutorDeEvento<bool>();
    }

    public void update()
    {
        if (deveMovimentar())
        {
            Vector3 result = Vector3.MoveTowards(cardDetalheDto.CardDetalhe.transform.position, posFinal, cardDetalheDto.Velocidade * Time.deltaTime);
            cardDetalheDto.CardDetalhe.transform.position = result;
            float distancia = Vector3.Distance(cardDetalheDto.CardDetalhe.transform.position, posFinal);
            if (distancia < 0.1f)
            {
                cardDetalheDto.CardDetalhe.transform.position = posFinal;
                posInicial = Vector3.zero;
                if (posOriginal == posFinal)
                {                
                    produtorDeEvento.produziuEvento(true);
                }
                else
                {
                    cardDetalheDto.CardDetalhe.SetActive(false);
                    produtorDeEvento.produziuEvento(false);
                }
            }
        }
    }

    public void movimentar(Vector3 posicaoInicial)
    {
        posInicial = posicaoInicial;
        posFinal   = posOriginal;
        cardDetalheDto.CardDetalhe.transform.position = posInicial;
        cardDetalheDto.CardDetalhe.SetActive(true);
    }

    public void voltar(Vector3 posicaoVoltar)
    {
        posInicial = posOriginal;
        posFinal   = posicaoVoltar;
        cardDetalheDto.CardDetalhe.transform.position = posOriginal;
        cardDetalheDto.CardDetalhe.SetActive(true);
    }

    private bool deveMovimentar()
    {
        return posInicial != Vector3.zero;
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
        cardDetalheDto.LblQtd.text = pupEntidade.getQtd().ToString();

        MaterialTipoPowerUpDto materialPup = pupEntidade.getMaterial();
        Material materialDetalhe = cardDetalheDto.MaterialDetalhe;
        materialDetalhe.SetTexture("_imgCard", pupEntidade.sprCard.texture);
        materialDetalhe.SetColor("_corPrincipal", materialPup.CorPrincipal);
        materialDetalhe.SetColor("_corCirculo", materialPup.CorCirculo);
        materialDetalhe.SetColor("_corEscura", materialPup.CorEscura);
    }
}
