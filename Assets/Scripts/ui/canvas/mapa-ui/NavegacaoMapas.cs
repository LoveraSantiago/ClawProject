using UnityEngine;

public class NavegacaoMapas : AcaoItemEscolhido<WrapperLevelMapDto>.ProdutorEvento
{
    private BotoesNavegacaoMapaDto botoesNavegacao;
    private NavegacaoDeArray<LevelMapDto> navegacaoDeArray;    

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
    }

    private void navegacaoDireita()
    {        
        LevelMapDto levelMapDto = navegacaoDeArray.getItemAnterior();
        produzirEvento(Direcao.DIREITA, levelMapDto);        
    }

    private void produzirEvento(Direcao direcao, LevelMapDto levelMapDto)
    {
        bool penultimo = navegacaoDeArray.isIndiceAtualPenultimo();
        bool ultimo = navegacaoDeArray.isIndiceAtualUltimo();
        Debug.Log("Penultimo " + penultimo + " Ultimo " + ultimo);
        WrapperLevelMapDto wrapperMapLevelDto = FactoryWrapperLevelMapDto.factory(direcao, levelMapDto, penultimo, ultimo);
        produtorDeEvento.produziuEvento(wrapperMapLevelDto);     
    }

    private void configurarMapasParaNavegacao(GameObject prefabLevelsDto)
    {
        PrefabLevelsDto prefabLevels = prefabLevelsDto.GetComponent<PrefabLevelsDto>();
        LevelMapDto[] levelsMapDto = prefabLevels.getLevelsMapDto(PlayerPrefsMapas.getMapaMaxLevel());
        navegacaoDeArray = new NavegacaoDeArray<LevelMapDto>(levelsMapDto, 0);
    }

    ProdutorDeEvento<WrapperLevelMapDto> ProdutorConsumidoresDeEvento<WrapperLevelMapDto>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
