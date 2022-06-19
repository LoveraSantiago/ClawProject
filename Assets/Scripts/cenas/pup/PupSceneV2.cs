using UnityEngine;
using UnityEngine.EventSystems;

#pragma warning disable 0649
public class PupSceneV2 : MonoBehaviour
{
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private CardPupDetalheDto cardDetalheDto;
    [Space(5)]
    [SerializeField] private CardsPupsDto[] cardsPupsDto;    
    [Space(5)]
    [SerializeField] private Animator animator;
    [Space(5)]
    [SerializeField] private GameObject prefabPowerUpDto;

    private Vector3 posOriginal;
    private bool isClicado;

    private TimerFicha timerFichaBronze;
    private CardDetalhePup cardDetalhe;
    private CanvasPupAnimacao animacao;

    // Start is called before the first frame update
    void Start()
    {
        Utils.configMainMono(this);
        timerFichaBronze = new TimerFicha(timerFichaDto, Ficha.BRONZE);
        cardDetalhe      = new CardDetalhePup(cardDetalheDto);
        animacao         = new CanvasPupAnimacao(animator);

        FactoryPowerUpEntidade.resetContextoEstatico();

        for (int contador = 0; contador < cardsPupsDto.Length; contador++)
        {
            cardsPupsDto[contador].Btn.onClick.AddListener(() => clicado());
        }

        new AcaoCardPupDetalheMovimentado()
            .configurarProdutor(cardDetalhe)
            .adicionarConsumidor(animacao);
    }

    // Update is called once per frame
    void Update()
    {
        timerFichaBronze.update();
        cardDetalhe.update();
    }

    public void clicado()
    {
        if(isClicado == false)
        {
            animacao.playFlipUpStop();            

            GameObject goSelecionado = EventSystem.current.currentSelectedGameObject;
            cardDetalhe.movimentar(goSelecionado.transform.position);            
            isClicado = true;            
        }
    }
}
