public class NavegacaoMapas : AcaoItemEscolhido<LevelMapDto>.ProdutorEvento
{
    private BotoesNavegacaoMapaDto botoesNavegacao;
    private NavegacaoDeArray<LevelMapDto> navegacaoDeArray;

    private ProdutorDeEvento<LevelMapDto> produtorDeEvento;

    public NavegacaoMapas(BotoesNavegacaoMapaDto botoesNavegacao, LevelMapDto[] levelsMapDto)
    {
        this.botoesNavegacao = botoesNavegacao;
        this.botoesNavegacao.BtnNavegacaoEsquerda.onClick.AddListener(() => navegacaoEsquerda());
        this.botoesNavegacao.BtnNavegacaoDireita.onClick.AddListener (() => navegacaoDireita());

        navegacaoDeArray = new NavegacaoDeArray<LevelMapDto>(levelsMapDto, 0);
        produtorDeEvento = new ProdutorDeEvento<LevelMapDto>();
    }

    public void inicializar()
    {
        LevelMapDto levelMapDto = navegacaoDeArray.getItemIndiceAtual();
        produtorDeEvento.produziuEvento(levelMapDto);
    }

    private void navegacaoEsquerda()
    {
        LevelMapDto levelMapDto = navegacaoDeArray.getItemAnterior();
        produtorDeEvento.produziuEvento(levelMapDto);
    }

    private void navegacaoDireita()
    {
        LevelMapDto levelMapDto = navegacaoDeArray.getItemProximo();
        produtorDeEvento.produziuEvento(levelMapDto);
    }

    ProdutorDeEvento<LevelMapDto> ProdutorConsumidoresDeEvento<LevelMapDto>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
