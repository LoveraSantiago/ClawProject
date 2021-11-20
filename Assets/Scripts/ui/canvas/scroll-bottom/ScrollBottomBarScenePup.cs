using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ScrollBottomBarScenePup : ScrollBottomBar,
                                       AcaoBBarItemEscolhido<int>.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBarScenePup(GameObject prefabBottomBar)
        : base(prefabBottomBar, new ItemsBottomBarPups())
    {
        produtorDeIndiceEscolhido = new ProdutorDeEvento<int>();
    }

    protected override void cliqueBoxAcionado(TextMeshProUGUI lblQtd)
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;
        produtorDeIndiceEscolhido.produziuEvento(int.Parse(nomeBtnSelecionado));
        btnBottomBar.btnBottomPressionado(this);
    }           

    ProdutorDeEvento<int> AcaoBBarItemEscolhido<int>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeIndiceEscolhido;
    }    
}
