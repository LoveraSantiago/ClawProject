using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class PupSceneV2 : MonoBehaviour
{
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private CardPupDetalheDto cardDetalheDto;
    [Space(5)]
    [SerializeField] private CanvasDetalheCardPupDto canvasDetalheDto;
    [Space(5)]
    [SerializeField] private CardsPupsDto[] cardsPupsDto;
    [Space(5)]
    [SerializeField] private FichaAnimadaDto fichaAnimadaDto;
    [Space(5)]
    [SerializeField] private Animator animator;
    [Space(5)]
    [SerializeField] private GameObject prefabPowerUpDto;    
    [Space(5)]
    [SerializeField] private ModalNoFichaDto modalNoFichaDto;

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
        PowerUpEntidade.configurarDicionarioDeSpritesPup(prefabPowerUpDto);

        timerFichaBronze = new TimerFicha(timerFichaDto, Ficha.BRONZE);
        cardDetalhe      = new CardDetalhePup(cardDetalheDto);
        animacao         = new AnimacaoCardsPup(animator);
        cardsPups        = new CardsPups(cardsPupsDto);
        canvasDetalhe    = new CanvasDetalhePup(canvasDetalheDto, modalNoFichaDto);
        fichaAnimada     = new FichaAnimada(fichaAnimadaDto);
        btnBack.onClick.AddListener(()=>voltar());

        new AcaoCardPupDetalheMovimentado()
            .configurarProdutor(cardDetalhe)
            .adicionarConsumidor(animacao)
            .adicionarConsumidor(cardsPups);

        new AcaoCardPowerUpSelecionado()
            .configurarProdutor(cardsPups)
            .adicionarConsumidor(cardDetalhe)
            .adicionarConsumidor(canvasDetalhe);

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
            cardsPups.forceClique(indicePrevio);
        }
    }
}
