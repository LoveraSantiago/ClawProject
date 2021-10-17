using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollBottomBarSceneColetaveis : ScrollBottomBar,
                                              AcaoBBarPupEscolhido<int>.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBarSceneColetaveis(GameObject prefabBottomBar) 
        : base(prefabBottomBar)
    {
        produtorDeIndiceEscolhido = new ProdutorDeEvento<int>();
    }

    protected override void cliqueBoxAcionado(TextMeshProUGUI lblQtd)
    {
        throw new System.NotImplementedException();
    }   

    ProdutorDeEvento<int> AcaoBBarPupEscolhido<int>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeIndiceEscolhido;
    }
}
