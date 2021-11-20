using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollBottomBarSceneColetaveis : ScrollBottomBar,
                                              AcaoBBarItemEscolhido<int>.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBarSceneColetaveis(
        GameObject prefabBottomBar,
        ColetavelEntidade.FAMILIA[] familias,
        Dictionary<string, Sprite> dicionarioDeSprites) 
        : base(prefabBottomBar, new ItemsBottomBarFamilias(familias, dicionarioDeSprites))
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
