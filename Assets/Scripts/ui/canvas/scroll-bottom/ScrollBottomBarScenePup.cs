using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ScrollBottomBarScenePup : ScrollBottomBar,
                                       AcaoBBarPupEscolhido<int>.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBarScenePup(GameObject prefabBottomBar)
        : base(prefabBottomBar)
    {
        produtorDeIndiceEscolhido = new ProdutorDeEvento<int>();
    }

    protected override void cliqueBoxAcionado(TextMeshProUGUI lblQtd)
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;
        produtorDeIndiceEscolhido.produziuEvento(int.Parse(nomeBtnSelecionado));
        btnBottomBar.btnBottomPressionado(this);
    }

    protected override int getQtdItems()
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        return allPups.Length;
    }

    protected override void recuperarDataFromItemIndice(int indice, out string qtdString, out Sprite spr)
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        PowerUpEntidade pupEntidade = allPups[indice];
        qtdString  = PlayerPrefsPup.recuperarQtdPup(pupEntidade.nome).ToString();
        spr = pupEntidade.sprPowerUp;
    }

    ProdutorDeEvento<int> AcaoBBarPupEscolhido<int>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeIndiceEscolhido;
    }
}
