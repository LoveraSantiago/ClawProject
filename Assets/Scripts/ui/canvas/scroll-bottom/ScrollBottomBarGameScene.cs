using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollBottomBarGameScene : ScrollBottomBar,
                                        AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                                        AcaoBotaoPUpVazio.ConsumidorEvento

{
    private int indiceBtn;
    
    private GameObject prefabBottomBar;
    private ProdutorDeEvento<PowerUpBtnInfo> produtorDeEvento;

    public ScrollBottomBarGameScene(GameObject prefabBottomBar)
       : base(prefabBottomBar)
    {
        this.prefabBottomBar = prefabBottomBar;
        produtorDeEvento = new ProdutorDeEvento<PowerUpBtnInfo>();
    }

    protected override void cliqueBoxAcionado()
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;        
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(int.Parse(nomeBtnSelecionado));
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);

        btnBottomBar.descerBotao();
        Utils.MonoBehaviour.StartCoroutine(finaizarBottomBar(pupBtnInfo));       
    }

    public void simularCliqueBoxAcionado(int indiceBtn, int indicePup)
    {        
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);

        produtorDeEvento.produziuEvento(pupBtnInfo);
    }

    public override void posCliqueBtnClose()
    {
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, null);
        Utils.MonoBehaviour.StartCoroutine(finaizarBottomBar(pupBtnInfo));
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        indiceBtn = evento;
        Utils.MonoBehaviour.StartCoroutine(mostrarBottomBar());
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
