using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour                                 
{
    [SerializeField] private MainColetaveisDto mainDto;

    private TimerFicha timerFichaOuro;
    private Prateleiras prateleiras;
    private SomManagerColetaveis somManager;
    private MovimentadorDeArmario movimentadorArmario;
    private CanvasDetalheColetavel detalheColetavel;

    void Start()
    {
        PrefabLevelsDto prefabLevels = mainDto.PrefabLevelsDto.GetComponent<PrefabLevelsDto>();

        ContextoEstaticoUtils.configMainMono(this);
        MateriaisUtils.configurar(mainDto.PrefabMateriais);
        HelperMapaEntidade.configurar(prefabLevels);

        PrefabLoading prefabLoading = mainDto.PrefabLoading.GetComponent<PrefabLoading>();
        somManager = new SomManagerColetaveis(mainDto.AudioColetaveisDto);
        prefabLoading.iniciarLoading(somManager, mainDto.GosDesligar);
        ContextoEstaticoUtils.loading.fecharModal();

        ColetaveisParaPrateleiras coletaveisParaPrateleiras = new ColetaveisParaPrateleiras();
        timerFichaOuro      = new TimerFicha(mainDto.TimerFichaDto, somManager, Ficha.OURO);
        prateleiras         = new Prateleiras(mainDto.PrateleirasDto, coletaveisParaPrateleiras, somManager);                
        movimentadorArmario = new MovimentadorDeArmario(mainDto, somManager);
        detalheColetavel    = new CanvasDetalheColetavel(mainDto, coletaveisParaPrateleiras, timerFichaOuro, somManager);

        configBtnBack(mainDto.BtnBack);
        mainDto.ScrollRect.onValueChanged.AddListener((posicao) => prateleiras.movimentado(posicao, mainDto.PrateleirasDto));

        new AcaoBtnPrateleiraAcionado()
            .configurarProdutor(prateleiras)
            .adicionarConsumidor(movimentadorArmario);

        new AcaoItemArmarioSelecionado()
            .configurarProdutor(movimentadorArmario)
            .adicionarConsumidor(detalheColetavel);

        restaurarArmario();
        somManager.playSomBackground();
    }

    private void Update()
    {
        timerFichaOuro.update();
    }    

    private void configBtnBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => {
                if (movimentadorArmario.isArmarioMovimentado())
                {
                    somManager.playSomCliqueItem();
                    detalheColetavel.fecharDetalhe();
                }
                else
                {
                    somManager.playSomCliqueVoltar();
                    ContextoEstaticoUtils.loading.irParaMapScene();
                }
            });
    }

    private void restaurarArmario()
    {
        int indice = PlayerPrefsColetaveis.recuperarEApagarNavegacaoColetavel();
        if(indice >= 0)
        {
            //Debug.Log("Restauracao SIM");
            PlayerPrefScrollArmarioDto playerPrefsDto  = PlayerPrefsScrollArmarioPosition.recuperarELimparPosScrollRectColetaveis();
            mainDto.ScrollRect.verticalNormalizedPosition = playerPrefsDto.posicaoScroll;
            //Debug.Log("Vertical normalized position " + scrollRect.verticalNormalizedPosition);            
            ColetavelEntidade coletavelEntidade = ContextoEstaticoUtils.mapaEntidade.getColetavelEntidadeByIndice(indice);
            while (!prateleiras.isPrateleiraVisivel(coletavelEntidade.indice))
            {
                prateleiras.movimentarParaBaixo(mainDto.PrateleirasDto);
                //Debug.Log("Movimentando para Baixo ");
            }

            PrateleiraArmarioDto prateleira = mainDto.PrateleirasDto.PrateleiraDto[playerPrefsDto.indicePrateleira];
            ItemPrateleiraDto itemSelecionado = prateleira.ItensPrateleira[playerPrefsDto.indiceItem];

            IndiceArmarioSelecionadoDto indiceArmarioSelecionado = new IndiceArmarioSelecionadoDto()
                .addIndices(playerPrefsDto.indicePrateleira, playerPrefsDto.indiceItem)
                .addScrollPosition(playerPrefsDto.posicaoScroll)
                .addItemSelecionado(itemSelecionado);

            movimentadorArmario.movimentarImediato(indiceArmarioSelecionado);
            detalheColetavel.detalheAberto(coletavelEntidade, indiceArmarioSelecionado);
        }
        else
        {
            //Debug.Log("Restauracao NAO");
        }
    }

    public void animacaoFecharDetalheEnd()
    {
        movimentadorArmario.voltar(mainDto.ScrollRect);
    }   
}
