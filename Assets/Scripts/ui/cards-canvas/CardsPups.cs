using UnityEngine;
using UnityEngine.EventSystems;

public class CardsPups : AcaoCardPowerUpSelecionado.ProdutorEvento
{
    private bool isClicado;
    private CardsPupsDto[] cardsPupsDto;
    private ProdutorDeEvento<CardPupSelecionadoDto> produtorDeEvento;

    public CardsPups(CardsPupsDto[] cardsPupsDto)
    {
        isClicado = false;
        this.cardsPupsDto = cardsPupsDto;
        produtorDeEvento = new ProdutorDeEvento<CardPupSelecionadoDto>();

        for (int contador = 0; contador < cardsPupsDto.Length; contador++)
        {
            cardsPupsDto[contador].Btn.onClick.AddListener(() => clicado());
        }
    }

    private void clicado()
    {
        if (isClicado == false)
        {
            GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
            string nomeParent = goSelecionado.transform.parent.name;

            PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(int.Parse(nomeParent));            
            CardPupSelecionadoDto cardSelecionado = new CardPupSelecionadoDto(goSelecionado.transform.position, pupEntidade);

            produtorDeEvento.produziuEvento(cardSelecionado);
        }
    }

    ProdutorDeEvento<CardPupSelecionadoDto> AcaoCardPowerUpSelecionado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
