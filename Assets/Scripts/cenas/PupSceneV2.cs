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
    private SomManagerPup    somManager;

    // Start is called before the first frame update
    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        FactoryPowerUpEntidade.resetContextoEstatico();

        PrefabLevelsDto prefabLevels = mainPupDto.PrefabLevesDto.GetComponent<PrefabLevelsDto>();
        HelperMapaEntidade.configurar(prefabLevels);
        PowerUpEntidade.configurarDicionarioDeSpritesPup(mainPupDto.PrefabPowerUpDto);

        PrefabLoading prefabLoading = mainPupDto.PrefabLoading.GetComponent<PrefabLoading>();
        somManager = new SomManagerPup(mainPupDto.AudioPupDto);
        prefabLoading.iniciarLoading(somManager, mainPupDto.GosDesligar);
        ContextoEstaticoUtils.loading.fecharModal();

        timerFichaBronze = new TimerFicha(mainPupDto.TimerFichaDto, somManager, Ficha.BRONZE);
        cardDetalhe      = new CardDetalhePup(mainPupDto.CardDetalheDto);
        animacao         = new AnimacaoCardsPup(mainPupDto.Animator);
        cardsPups        = new CardsPups(mainPupDto.CardsPupsDto);
        canvasDetalhe    = new CanvasDetalhePup(mainPupDto.CanvasDetalheDto, mainPupDto.ModalNoFichaDto);
        fichaAnimada     = new FichaAnimada(mainPupDto.FichaAnimadaDto);
        configBtnBack(mainPupDto.BtnBack);        

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

        somManager.playSomBackground();
    }

    // Update is called once per frame
    void Update()
    {
        timerFichaBronze.update();
        cardDetalhe.update();
    }   

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => {
            if (canvasDetalhe.isAberto)
            {
                animacao.playFlipUp();
            }
            else
            {
                somManager.playSomCliqueVoltar();
                ContextoEstaticoUtils.loading.irParaMapScene();
            }
        });
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
