using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollBottomBarGameScene : ScrollBottomBar,
                                        AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                                        AcaoBotaoPUpVazio.ConsumidorEvento

{
    private int indiceBtn;

    private MonoBehaviour monoBehaviour;
    private GameObject prefabBottomBar;

    private ProdutorDeEvento<PowerUpBtnInfo> produtorDeEvento;

    public ScrollBottomBarGameScene(GameObject prefabBottomBar, MonoBehaviour monoBehaviour)
       : base(prefabBottomBar, monoBehaviour)
    {
        this.prefabBottomBar = prefabBottomBar;
        this.monoBehaviour = monoBehaviour;

        produtorDeEvento = new ProdutorDeEvento<PowerUpBtnInfo>();
    }

    protected override void cliqueAcionado()
    {
        monoBehaviour.StartCoroutine(esconderBottomBar());       
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        indiceBtn = evento;
        monoBehaviour.StartCoroutine(mostrarBottomBar());
    }

    private IEnumerator esconderBottomBar()
    {
        btnBottomBar.descerBotao();
        yield return new WaitForSecondsRealtime(1f);
        prefabBottomBar.SetActive(false);

        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        PowerUpEntidade pupEscolhido = allPups[int.Parse(nomeBtnSelecionado)];

        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);
        produtorDeEvento.produziuEvento(pupBtnInfo);
    }

    private IEnumerator mostrarBottomBar()
    {
        yield return new WaitForSecondsRealtime(1f);
        prefabBottomBar.SetActive(true);
        btnBottomBar.subirBotao();
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEvento;
    }
}
