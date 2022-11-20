public class NavegacaoMapas : AcaoMapaNavegado.ProdutorEvento
{
    private BotoesNavegacaoMapaDto botoesNavegacao;
    private NavegacaoDeArray<MapaEntidade> navegacaoDeArray;
    private WrapperLevelMapDto wrapperMapLevelAtual;

    private ProdutorDeEvento<WrapperLevelMapDto> produtorDeEvento;

    public NavegacaoMapas(BotoesNavegacaoMapaDto botoesNavegacao, SomMap somMap)
    {
        this.botoesNavegacao = botoesNavegacao;
        this.botoesNavegacao.BtnNavegacaoEsquerda.onClick.AddListener(() => navegacaoEsquerda(somMap));
        this.botoesNavegacao.BtnNavegacaoDireita.onClick.AddListener (() => navegacaoDireita(somMap));

        configurarMapasParaNavegacao();
        produtorDeEvento = new ProdutorDeEvento<WrapperLevelMapDto>();        
    }

    public void inicializar()
    {
        MapaEntidade mapaEntidade = navegacaoDeArray.getItemIndiceAtual();
        produzirEvento(Direcao.CENTRALIZADA, mapaEntidade);
    }    

    private void navegacaoEsquerda(SomMap somMap)
    {
        somMap.playSomCliqueSetas();
        MapaEntidade mapaEntidade = navegacaoDeArray.getItemProximo();
        produzirEvento(Direcao.ESQUERDA, mapaEntidade);
        dismissExclamacao();
    }

    private void navegacaoDireita(SomMap somMap)
    {
        somMap.playSomCliqueSetas();
        MapaEntidade mapaEntidade = navegacaoDeArray.getItemAnterior();
        produzirEvento(Direcao.DIREITA, mapaEntidade);
        dismissExclamacao();
    }

    private void produzirEvento(Direcao direcao, MapaEntidade mapaEntidade)
    {
        wrapperMapLevelAtual = new WrapperLevelMapDto(direcao, mapaEntidade);

        //Debug.Log("estado " + wrapperMapLevelAtual.mapaEstado);
        ContextoEstaticoUtils.configMapaEntidade(wrapperMapLevelAtual.mapaEntidade);
        produtorDeEvento.produziuEvento(wrapperMapLevelAtual);     
    }

    private void configurarMapasParaNavegacao()
    {
        MapaEntidade[] mapas = HelperMapaEntidade.getMapaEntidadesLiberados(2);
        mapas[mapas.Length - 1].lockar();
        mapas[mapas.Length - 2].bloquear();
        mapas[mapas.Length - 3].emProgresso();

        MapaEntidade mapaNavegacao = ContextoEstaticoUtils.loadMapaEntidade();
        navegacaoDeArray = new NavegacaoDeArray<MapaEntidade>(mapas, mapaNavegacao.id - 1);
        if (PlayerPrefsMapas.isNovaLiberacaoMapa())
        {
            botoesNavegacao.GoExclamacao.SetActive(true);
        }
    }

    private void dismissExclamacao()
    {
        if (wrapperMapLevelAtual.mapaEntidade.isProgresso)
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
