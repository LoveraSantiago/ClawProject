using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollBottomBarPupScene : ScrollBottomBar,
                                       AcaoPupIndice.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBarPupScene(ScrollBottomBarDto scrollBottomBarDto, MonoBehaviour monoBehaviour)
        : base(scrollBottomBarDto, monoBehaviour)
    {
        produtorDeIndiceEscolhido = new ProdutorDeEvento<int>();
    }

    protected override void cliqueAcionado()
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;
        produtorDeIndiceEscolhido.produziuEvento(int.Parse(nomeBtnSelecionado));
    }

    ProdutorDeEvento<int> AcaoPupIndice.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeIndiceEscolhido;
    }
}
