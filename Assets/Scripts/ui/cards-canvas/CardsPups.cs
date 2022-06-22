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
        if (isClicado == false)
        {
            GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
            GameObject goParent = goSelecionado.transform.parent.gameObject;
            string nomeParent = goParent.name;

            int indice = int.Parse(nomeParent);
            PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indice);            
            cardSelecionado = new CardPupSelecionadoDto(indice, goSelecionado.transform.position, pupEntidade);
            
            produtorDeEvento.produziuEvento(cardSelecionado);
            goParent.SetActive(false);
        }
    }

    void AcaoCardPupDetalheMovimentado.ConsumidorEvento.consumirEvento(bool evento)
    {
        if (!evento)
        {
            isClicado = false;
            CardsPupsDto cardPupDto = cardsPupsDto[cardSelecionado.indice];
            GameObject goParent = cardPupDto.ImgCard.transform.parent.parent.gameObject;
            goParent.SetActive(true);            
        }
    }

    ProdutorDeEvento<CardPupSelecionadoDto> AcaoCardPowerUpSelecionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
