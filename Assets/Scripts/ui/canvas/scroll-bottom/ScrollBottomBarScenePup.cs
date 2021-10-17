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

    protected override ItemsBottomBar getItemsBottomBar()
    {
        return new Temporaria();
    }

    ProdutorDeEvento<int> AcaoBBarPupEscolhido<int>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeIndiceEscolhido;
    }

    class Temporaria : ItemsBottomBar
    {
        private PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();

        public string getLabelQtdDoItemIndice(int indice)
        {
            PowerUpEntidade pupEntidade = allPups[indice];
            return PlayerPrefsPup.recuperarQtdPup(pupEntidade.nome).ToString();
        }

        public int getQtdItems()
        {
            return allPups.Length;
        }

        public Sprite getSprDoItemIndice(int indice)
        {
            return allPups[indice].sprPowerUp;
        }
    }
}
