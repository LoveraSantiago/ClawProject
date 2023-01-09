using UnityEngine;
using UnityEngine.EventSystems;

public class CardsPups : AcaoCardPowerUpSelecionado.ProdutorEvento,
                         AcaoCardPupDetalheMovimentado.ConsumidorEvento
{
    private bool isClicado;
    private CardsPupsDto[] cardsPupsDto;
    private ProdutorDeEvento<CardPupSelecionadoDto> produtorDeEvento;

    private CardPupSelecionadoDto cardSelecionado;

    public CardsPups(CardsPupsDto[] cardsPupsDto, SomManagerPup somManager)
    {
        isClicado = false;
        this.cardsPupsDto = cardsPupsDto;
        produtorDeEvento = new ProdutorDeEvento<CardPupSelecionadoDto>();
        popularCards(somManager);
    }

    public CardPupSelecionadoDto recuperarUltimoCardSelecionado()
    {
        return cardSelecionado;
    }

    public void forceClique(int indice, SomManagerPup somManager)
    {
        CardsPupsDto cardPupIt = cardsPupsDto[indice];
        clicado(cardPupIt.Btn.gameObject, true, somManager);
    }

    private void popularCards(SomManagerPup somManager)
    {
        PowerUpEntidade[] pupEntidades = FactoryPowerUpEntidade.getAllPowerUps();
        for (int contador = 0; contador < cardsPupsDto.Length; contador++)
        {
            CardsPupsDto cardPupIt = cardsPupsDto[contador];
            cardPupIt.Btn.onClick.AddListener(() => clicado(somManager));

            PowerUpEntidade pupEntidade = pupEntidades[contador];
            cardPupIt.ImgCard.sprite    = pupEntidade.sprCard;
            cardPupIt.LblPreco.text     = pupEntidade.preco;
            cardPupIt.LblQtd.text       = pupEntidade.getQtd().ToString();
            cardPupIt.ImgContornoCard.material = pupEntidade.getMaterial().Material;
        }
    }

    private void clicado(SomManagerPup somManager)
    {
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        clicado(goSelecionado, false, somManager);
    }    

    private void clicado(GameObject goSelecionado, bool restauracaoTela, SomManagerPup somManager)
    {
        if (isClicado == false && goSelecionado != null)
        {
            GameObject goParent = goSelecionado.transform.parent.parent.gameObject;
            string nomeParent = goParent.name;

            int indice = int.Parse(nomeParent);
            PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indice);
            cardSelecionado = new CardPupSelecionadoDto()
                .addIndice(indice)
                .addPosicaoCardSelecionado(goSelecionado.transform.position)
                .addPupSelecionado(pupEntidade)
                .addRestauracaoTela(restauracaoTela);

            produtorDeEvento.produziuEvento(cardSelecionado);
            if (!restauracaoTela)
            {
                somManager.playSomCliqueItem();
            }
            goParent.SetActive(false);
            isClicado = true;
        }
    }

    void AcaoCardPupDetalheMovimentado.ConsumidorEvento.consumirEvento(CardPupDetalheMovimentadoDto evento)
    {
        if (evento.isFlipUp)
        {
            CardsPupsDto cardPupDto = cardsPupsDto[cardSelecionado.indice];
            GameObject goParent = cardPupDto.ImgCard.transform.parent.parent.parent.gameObject;
            goParent.SetActive(true);            
            isClicado = false;
        }
    }

    ProdutorDeEvento<CardPupSelecionadoDto> AcaoCardPowerUpSelecionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
