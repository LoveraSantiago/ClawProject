using UnityEngine;

public class NavegacaoMapas : AcaoMapaNavegado.ProdutorEvento
{
    private BotoesNavegacaoMapaDto botoesNavegacao;
    private NavegacaoDeArray<LevelMapDto> navegacaoDeArray;
    private WrapperLevelMapDto wrapperMapLevelAtual;

    private ProdutorDeEvento<WrapperLevelMapDto> produtorDeEvento;

    public NavegacaoMapas(BotoesNavegacaoMapaDto botoesNavegacao, GameObject prefabLevelsDto)
    {
        this.botoesNavegacao = botoesNavegacao;
        this.botoesNavegacao.BtnNavegacaoEsquerda.onClick.AddListener(() => navegacaoEsquerda());
        this.botoesNavegacao.BtnNavegacaoDireita.onClick.AddListener (() => navegacaoDireita());

        configurarMapasParaNavegacao(prefabLevelsDto);
        produtorDeEvento = new ProdutorDeEvento<WrapperLevelMapDto>();        
    }

    public void inicializar()
    {
        LevelMapDto levelMapDto = navegacaoDeArray.getItemIndiceAtual();
        produzirEvento(Direcao.CENTRALIZADA, levelMapDto);
    }    

    private void navegacaoEsquerda()
    {        
        LevelMapDto levelMapDto = navegacaoDeArray.getItemProximo();
        produzirEvento(Direcao.ESQUERDA, levelMapDto);
        dismissExclamacao();
    }

    private void navegacaoDireita()
    {        
        LevelMapDto levelMapDto = navegacaoDeArray.getItemAnterior();
        produzirEvento(Direcao.DIREITA, levelMapDto);
        dismissExclamacao();
    }

    private void produzirEvento(Direcao direcao, LevelMapDto levelMapDto)
    {
        bool isAntePenultimo = navegacaoDeArray.isIndiceAtualAntepenultimo();
        bool penultimo       = navegacaoDeArray.isIndiceAtualPenultimo();
        bool ultimo          = navegacaoDeArray.isIndiceAtualUltimo();
        //Debug.Log("Penultimo " + penultimo + " Ultimo " + ultimo);

        EstadoOrdemMapaDto estadoOrdem = new EstadoOrdemMapaDto(isAntePenultimo, penultimo, ultimo);        
        wrapperMapLevelAtual = FactoryWrapperLevelMapDto.factory(direcao, levelMapDto, estadoOrdem);
        ContextoEstaticoUtils.configMapaEntidade(wrapperMapLevelAtual.mapaEntidade);
        produtorDeEvento.produziuEvento(wrapperMapLevelAtual);     
    }

    private void configurarMapasParaNavegacao(GameObject prefabLevelsDto)
    {
        PrefabLevelsDto prefabLevels = prefabLevelsDto.GetComponent<PrefabLevelsDto>();
        LevelMapDto[] levelsMapDto = prefabLevels.getLevelsMapDto();
        MapaEntidade mapaNavegacao = ContextoEstaticoUtils.loadMapaEntidade();
        navegacaoDeArray = new NavegacaoDeArray<LevelMapDto>(levelsMapDto, mapaNavegacao.id - 1);
        if (PlayerPrefsMapas.isNovaLiberacaoMapa())
        {
            botoesNavegacao.GoExclamacao.SetActive(true);
        }
    }

    private void dismissExclamacao()
    {
        if (wrapperMapLevelAtual.isEmAndamento)
        {
            PlayerPrefsMapas.consumidoNovaLiberacaoMapa();
            botoesNavegacao.GoExclamacao.SetActive(false);
        }
    }

    ProdutorDeEvento<WrapperLevelMapDto> AcaoMapaNavegado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
