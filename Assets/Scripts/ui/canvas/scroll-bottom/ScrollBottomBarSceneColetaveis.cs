using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollBottomBarSceneColetaveis : ScrollBottomBar,
                                              AcaoBBarPupEscolhido<int>.ProdutorEvento
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
        throw new System.NotImplementedException();
    }    

    ProdutorDeEvento<int> AcaoBBarPupEscolhido<int>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeIndiceEscolhido;
    }    
}
