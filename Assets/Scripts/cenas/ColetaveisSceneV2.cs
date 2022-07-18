using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour 
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
    [SerializeField] private GameObject prefabMateriais;
    [SerializeField] private GameObject prefabColetaveisDto;

    private float ultimaPosicao;

    private TimerFicha timerFichaOuro;
    private Prateleiras prateleiras;    
    private MovimentadorDeArmario movimentadorArmario;

    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);
        HelperColetavelEntidade.configurar(prefabColetaveisDto);

        PlayerPrefsColetaveis.unlockFamilia(ColetavelEntidade.FAMILIA.FRUTAS.ToString());//TEMPORARIAMENTE AQUI               

        timerFichaOuro = new TimerFicha(timerFichaDto, Ficha.OURO);
        prateleiras    = new Prateleiras(prateleirasDto);

        scrollRect.onValueChanged.AddListener((pos) => movimentado(pos));
        ultimaPosicao = 1;

        popularBotoes();
        //movimentadorArmario = new MovimentadorDeArmarioFixo(prateleirasDto);
        movimentadorArmario = new MovimentadorDeArmarioMovel(prateleirasDto, movimentadorDto);
        configBtnBack(btnBack);
    }

    private void Update()
    {
        timerFichaOuro.update();
    }

    private void movimentado(Vector2 posicao)
    {
        float result = ultimaPosicao - posicao.y;
        if(result > 0)
        {
            prateleiras.movimentarParaBaixo(prateleirasDto);
        }
        else if(result < 0)
        {
            prateleiras.movimentarParaCima(prateleirasDto);
        }
        ultimaPosicao = posicao.y;        
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
        movimentadorArmario.movimentar(scrollRect, prateleirasDto);       
    }

    private void configBtnBack(Button btnBack)
    {
        if (movimentadorArmario.isArmarioMovimentado())
        {
            movimentadorArmario.voltar();
        }
        else
        {
            btnBack.onClick.AddListener(() => CenaUtils.irParaCenaMap());
        }
    }
}
