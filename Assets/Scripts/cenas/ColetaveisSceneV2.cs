using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour,
                                 AcaoItemArmarioSelecionado.ConsumidorEvento
{
    [SerializeField] private MainColetaveisDto mainDto;

    private TimerFicha timerFichaOuro;
    private Prateleiras prateleiras;    
    private MovimentadorDeArmario movimentadorArmario;
    private CanvasDetalheColetavel detalheColetavel;

    void Start()
    {
        ContextoEstaticoUtils.configMainMono(this);
        MateriaisUtils.configurar(mainDto.PrefabMateriais);

        PrefabLevelsDto prefabLevels = mainDto.PrefabLevelsDto.GetComponent<PrefabLevelsDto>();
        FactoryMapaEntidade.configurar(prefabLevels);

        PlayerPrefsColetaveis.unlockFamilia(MapaEnum.FRUTAS.ToString());//TEMPORARIAMENTE AQUI               

        timerFichaOuro = new TimerFicha(mainDto.TimerFichaDto, Ficha.OURO);
        ColetaveisParaPrateleiras coletaveisParaPrateleiras = new ColetaveisParaPrateleiras();

        prateleiras    = new Prateleiras(mainDto.PrateleirasDto, coletaveisParaPrateleiras);

        mainDto.ScrollRect.onValueChanged.AddListener((pos) => prateleiras.movimentado(pos, mainDto.PrateleirasDto));
                
        movimentadorArmario = new MovimentadorDeArmario(mainDto);
        detalheColetavel = new CanvasDetalheColetavel(mainDto);
        configBtnBack(mainDto.BtnBack);

        new AcaoBtnPrateleiraAcionado()
            .configurarProdutor(prateleiras)
            .adicionarConsumidor(movimentadorArmario);

        new AcaoItemArmarioSelecionado()
            .configurarProdutor(movimentadorArmario)
            .adicionarConsumidor(this);

        restaurarArmario();
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
            mainDto.ScrollRect.verticalNormalizedPosition = indiceArmarioSelecionado.posScrollArmario;
            //Debug.Log("Vertical normalized position " + scrollRect.verticalNormalizedPosition);            
            ColetavelEntidade coletavelEntidade = ContextoEstaticoUtils.mapaEntidade.getColetavelEntidadeByIndice(indice);
            while (!prateleiras.isPrateleiraVisivel(coletavelEntidade.ordem))
            {
                prateleiras.movimentarParaBaixo(mainDto.PrateleirasDto);
                //Debug.Log("Movimentando para Baixo ");
            }
            movimentadorArmario.movimentarImediato(indiceArmarioSelecionado);
            detalheColetavel.detalheAberto(coletavelEntidade, indiceArmarioSelecionado, mainDto.PrateleirasDto);
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

    void AcaoItemArmarioSelecionado.ConsumidorEvento.consumirEvento(IndiceArmarioSelecionadoDto evento)
    {
        //Debug.Log("Vertical normalized position " + scrollRect.verticalNormalizedPosition);
        IndiceArmarioSelecionadoDto indiceArmario = new IndiceArmarioSelecionadoDto(evento, mainDto.ScrollRect.verticalNormalizedPosition);
        detalheColetavel.abrirDetalhe(indiceArmario, mainDto.PrateleirasDto);
    }
}
