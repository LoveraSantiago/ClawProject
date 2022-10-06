using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class PupSceneV2 : MonoBehaviour,
                          AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    [SerializeField] private MainPupDto mainPupDto;                

    private TimerFicha       timerFichaBronze;
    private CardDetalhePup   cardDetalhe;
    private CardsPups        cardsPups;
    private AnimacaoCardsPup animacao;
    private CanvasDetalhePup canvasDetalhe;
    private FichaAnimada     fichaAnimada;

    // Start is called before the first frame update
    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        FactoryPowerUpEntidade.resetContextoEstatico();

        PrefabLevelsDto prefabLevels = mainPupDto.PrefabLevesDto.GetComponent<PrefabLevelsDto>();
        HelperMapaEntidade.configurar(prefabLevels);
        PowerUpEntidade.configurarDicionarioDeSpritesPup(mainPupDto.PrefabPowerUpDto);

        timerFichaBronze = new TimerFicha(mainPupDto.TimerFichaDto, Ficha.BRONZE);
        cardDetalhe      = new CardDetalhePup(mainPupDto.CardDetalheDto);
        animacao         = new AnimacaoCardsPup(mainPupDto.Animator);
        cardsPups        = new CardsPups(mainPupDto.CardsPupsDto);
        canvasDetalhe    = new CanvasDetalhePup(mainPupDto.CanvasDetalheDto, mainPupDto.ModalNoFichaDto);
        fichaAnimada     = new FichaAnimada(mainPupDto.FichaAnimadaDto);
        mainPupDto.BtnBack.onClick.AddListener(()=>voltar());

        new AcaoCardPupDetalheMovimentado()
            .configurarProdutor(cardDetalhe)
            .adicionarConsumidor(animacao)
            .adicionarConsumidor(cardsPups);

        new AcaoCardPowerUpSelecionado()
            .configurarProdutor(cardsPups)
            .adicionarConsumidor(cardDetalhe)
            .adicionarConsumidor(canvasDetalhe)
            .adicionarConsumidor(this);

        new AcaoBotaoPowerUpEscolhido()
            .configurarProdutor(canvasDetalhe)
            .adicionarConsumidor(fichaAnimada)
            .adicionarConsumidor(animacao);

        restaurarTela();
    }

    // Update is called once per frame
    void Update()
    {
        timerFichaBronze.update();
        cardDetalhe.update();
    }

    private void voltar()
    {
        if (canvasDetalhe.isAberto)
        {
            animacao.playFlipUp();
        }
        else
        {
            CenaUtils.irParaCenaMap();
        }
    }      
    
    public void animacaoFlipUpEnd()
    {
        canvasDetalhe.dismiss();
        CardPupSelecionadoDto cardSelecionado = cardsPups.recuperarUltimoCardSelecionado();
        cardDetalhe.voltar(cardSelecionado.posicaoCard);
    }

    private void restaurarTela()
    {
        int indicePrevio = PlayerPrefsPowerUp.recuperarEApagarIndicePup();        
        if(indicePrevio > -1)
        {
            mainPupDto.ScrollRect.verticalNormalizedPosition = PlayerPrefsPowerUp.getPosScroll();
            cardsPups.forceClique(indicePrevio);
        }
    }

    void AcaoCardPowerUpSelecionado.ConsumidorEvento.consumirEvento(CardPupSelecionadoDto evento)
    {
        if (!evento.restauracaoTela)
        {
            PlayerPrefsPowerUp.salvarPosScroll(mainPupDto.ScrollRect.verticalNormalizedPosition);
        }
    }
}
