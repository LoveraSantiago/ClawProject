using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour,
                                 AcaoItemArmarioSelecionado.ConsumidorEvento
{       
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private Button btnBack;
    [Space(5)]    
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]
    [SerializeField] private MovimentadorArmarioDto movimentadorDto;
    [Space(5)]
    [SerializeField] private PrateleirasDto prateleirasDto;
    [Space(5)]
    [SerializeField] private CanvasDetalheColetavelDto canvasDetalheColetavelDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabColetaveisDto;
    [Space(5)]
    [SerializeField] private ModalNoFichaDto modalNoFichaDto;

    private TimerFicha timerFichaOuro;
    private Prateleiras prateleiras;    
    private MovimentadorDeArmario movimentadorArmario;
    private CanvasDetalheColetavel detalheColetavel;

    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);
        HelperColetavelEntidade.configurar(prefabColetaveisDto);

        PlayerPrefsColetaveis.unlockFamilia(MapaEnum.FRUTAS.ToString());//TEMPORARIAMENTE AQUI               

        timerFichaOuro = new TimerFicha(timerFichaDto, Ficha.OURO);
        prateleiras    = new Prateleiras(prateleirasDto);

        scrollRect.onValueChanged.AddListener((pos) => prateleiras.movimentado(pos, prateleirasDto));

        popularBotoes();
        movimentadorArmario = new MovimentadorDeArmario(prateleirasDto, movimentadorDto);
        detalheColetavel = new CanvasDetalheColetavel(canvasDetalheColetavelDto, modalNoFichaDto);
        configBtnBack(btnBack);

        new AcaoItemArmarioSelecionado()
            .configurarProdutor(movimentadorArmario)
            .adicionarConsumidor(this);

        restaurarArmario();
    }

    private void Update()
    {
        timerFichaOuro.update();
    }

    private void popularBotoes()
    {
        for (int contadorPrateleiras = 0; contadorPrateleiras < prateleirasDto.PrateleiraDto.Length; contadorPrateleiras++)
        {
            PrateleiraArmarioDto prateleiraDtoIt = prateleirasDto.PrateleiraDto[contadorPrateleiras];
            for (int contadorItens = 0; contadorItens < prateleiraDtoIt.ItensPrateleira.Length; contadorItens++)
            {
                ItemPrateleiraDto itemPrateleiraIt = prateleiraDtoIt.ItensPrateleira[contadorItens];
                itemPrateleiraIt.BtnItem.onClick.AddListener(() => movimentarArmario());
            }
        }
    }
    
    private void movimentarArmario()
    {
        if (!movimentadorArmario.isArmarioMovimentado())
        {
            movimentadorArmario.movimentarAnimado(scrollRect, prateleirasDto);       
        }
    }

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => {
                if (movimentadorArmario.isArmarioMovimentado())
                {
                    detalheColetavel.fecharDetalhe();
                }
                else
                {
                    CenaUtils.irParaCenaMap();
                }
            });
    }

    private void restaurarArmario()
    {
        int indice = PlayerPrefsColetaveis.recuperarEApagarNavegacaoColetavel();
        if(indice != 0)
        {
            //Debug.Log("Restauracao SIM");
            IndiceArmarioSelecionadoDto indiceArmarioSelecionado =PlayerPrefsScrollPosition.recuperarELimparPosScrollRectColetaveis();
            scrollRect.verticalNormalizedPosition = indiceArmarioSelecionado.posScrollArmario;
            //Debug.Log("Vertical normalized position " + scrollRect.verticalNormalizedPosition);
            HelperColetavelEntidade helper = new HelperColetavelEntidade();
            ColetavelEntidade coletavelEntidade = helper.getColetavelEntidadeById(indice);
            while (!prateleiras.isPrateleiraVisivel(coletavelEntidade.ordem))
            {
                prateleiras.movimentarParaBaixo(prateleirasDto);
                //Debug.Log("Movimentando para Baixo ");
            }
            movimentadorArmario.movimentarImediato(indiceArmarioSelecionado, scrollRect, prateleirasDto);
            detalheColetavel.detalheAberto(coletavelEntidade, indiceArmarioSelecionado, prateleirasDto);
        }
        else
        {
            //Debug.Log("Restauracao NAO");
        }
    }

    public void animacaoFecharDetalheEnd()
    {
        movimentadorArmario.voltar(scrollRect);
    }

    void AcaoItemArmarioSelecionado.ConsumidorEvento.consumirEvento(IndiceArmarioSelecionadoDto evento)
    {
        //Debug.Log("Vertical normalized position " + scrollRect.verticalNormalizedPosition);
        IndiceArmarioSelecionadoDto indiceArmario = new IndiceArmarioSelecionadoDto(evento, scrollRect.verticalNormalizedPosition);
        detalheColetavel.abrirDetalhe(indiceArmario, prateleirasDto);
    }
}
