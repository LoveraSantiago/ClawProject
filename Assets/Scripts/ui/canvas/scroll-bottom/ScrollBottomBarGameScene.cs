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

    protected override void cliqueBoxAcionado()
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        PowerUpEntidade pupEscolhido = allPups[int.Parse(nomeBtnSelecionado)];
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);

        btnBottomBar.descerBotao();
        monoBehaviour.StartCoroutine(finaizarBottomBar(pupBtnInfo));       
    }

    public override void posCliqueBtnClose()
    {
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, null);
        monoBehaviour.StartCoroutine(finaizarBottomBar(pupBtnInfo));
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        indiceBtn = evento;
        monoBehaviour.StartCoroutine(mostrarBottomBar());
    }

    private IEnumerator finaizarBottomBar(PowerUpBtnInfo pupBtnInfo)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        prefabBottomBar.SetActive(false);        

        produtorDeEvento.produziuEvento(pupBtnInfo);
    }

    private IEnumerator mostrarBottomBar()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        prefabBottomBar.SetActive(true);
        btnBottomBar.subirBotao();
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
