using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollBottomBarPupScene : ScrollBottomBar,
                                       AcaoBBarPupEscolhido<int>.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBarPupScene(GameObject prefabBottomBar)
        : base(prefabBottomBar)
    {
        produtorDeIndiceEscolhido = new ProdutorDeEvento<int>();
    }

    protected override void cliqueBoxAcionado()
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;
        produtorDeIndiceEscolhido.produziuEvento(int.Parse(nomeBtnSelecionado));
        btnBottomBar.btnBottomPressionado(this);
    }

    ProdutorDeEvento<int> AcaoBBarPupEscolhido<int>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeIndiceEscolhido;
    }
}
