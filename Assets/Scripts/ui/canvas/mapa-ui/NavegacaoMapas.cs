using UnityEngine;

public class NavegacaoMapas : AcaoItemEscolhido<WrapperLevelMapDto>.ProdutorEvento
{
    private BotoesNavegacaoMapaDto botoesNavegacao;
    private NavegacaoDeArray<LevelMapDto> navegacaoDeArray;    

    private ProdutorDeEvento<WrapperLevelMapDto> produtorDeEvento;

    public NavegacaoMapas(BotoesNavegacaoMapaDto botoesNavegacao, LevelMapDto[] levelsMapDto)
    {
        this.botoesNavegacao = botoesNavegacao;
        this.botoesNavegacao.BtnNavegacaoEsquerda.onClick.AddListener(() => navegacaoEsquerda());
        this.botoesNavegacao.BtnNavegacaoDireita.onClick.AddListener (() => navegacaoDireita());

        navegacaoDeArray = new NavegacaoDeArray<LevelMapDto>(levelsMapDto, 0);
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

    ProdutorDeEvento<WrapperLevelMapDto> ProdutorConsumidoresDeEvento<WrapperLevelMapDto>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
