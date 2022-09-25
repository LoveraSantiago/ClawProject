using UnityEngine;
using UnityEngine.EventSystems;

public class CardsPups : AcaoCardPowerUpSelecionado.ProdutorEvento,
                         AcaoCardPupDetalheMovimentado.ConsumidorEvento
{
    private bool isClicado;
    private CardsPupsDto[] cardsPupsDto;
    private ProdutorDeEvento<CardPupSelecionadoDto> produtorDeEvento;

    private CardPupSelecionadoDto cardSelecionado;

    public CardsPups(CardsPupsDto[] cardsPupsDto)
    {
        isClicado = false;
        this.cardsPupsDto = cardsPupsDto;
        produtorDeEvento = new ProdutorDeEvento<CardPupSelecionadoDto>();
        popularCards();
    }

    public CardPupSelecionadoDto recuperarUltimoCardSelecionado()
    {
        return cardSelecionado;
    }

    public void forceClique(int indice)
    {
        CardsPupsDto cardPupIt = cardsPupsDto[indice];
        clicado(cardPupIt.Btn.gameObject, true);
    }

    private void popularCards()
    {
        PowerUpEntidade[] pupEntidades = FactoryPowerUpEntidade.getAllPowerUps();
        for (int contador = 0; contador < cardsPupsDto.Length; contador++)
        {
            CardsPupsDto cardPupIt = cardsPupsDto[contador];
            cardPupIt.Btn.onClick.AddListener(() => clicado());

            PowerUpEntidade pupEntidade = pupEntidades[contador];
            cardPupIt.ImgCard.sprite    = pupEntidade.sprCard;
            cardPupIt.LblPreco.text     = pupEntidade.preco;
            cardPupIt.LblQtd.text       = pupEntidade.getQtd().ToString();
            cardPupIt.ImgContornoCard.material = pupEntidade.getMaterial().Material;
        }
    }

    private void clicado()
    {
        GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
        clicado(goSelecionado, false);
    }    

    private void clicado(GameObject goSelecionado, bool restauracaoTela)
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
