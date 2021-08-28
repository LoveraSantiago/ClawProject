using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollBottomBarPupScene : ScrollBottomBar,
                                       AcaoPupIndice.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBarPupScene(GameObject prefabBottomBar, MonoBehaviour monoBehaviour)
        : base(prefabBottomBar, monoBehaviour)
    {
        produtorDeIndiceEscolhido = new ProdutorDeEvento<int>();
    }

    protected override void cliqueAcionado()
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;
        produtorDeIndiceEscolhido.produziuEvento(int.Parse(nomeBtnSelecionado));
        btnBottomBar.btnBottomPressionado();
    }

    ProdutorDeEvento<int> AcaoPupIndice.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeIndiceEscolhido;
    }
}
