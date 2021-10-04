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
        int qtdPup = PlayerPrefsPup.recuperarQtdPup(pupEscolhido.nome);
        btnBottomBar.descerBotao(this);
        if(qtdPup > 0)
        {
            PlayerPrefsPup.subtrairPup(pupEscolhido.nome);
            PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);
            Utils.MonoBehaviour.StartCoroutine(finalizarBottomBar(pupBtnInfo));       
        }
        else
        {        
            PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn);
            Utils.MonoBehaviour.StartCoroutine(finalizarBottomBar(pupBtnInfo));
        }
    }

    public void simularCliqueBoxAcionado(int indiceBtn, int indicePup)
    {        
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);

        produtorDeEvento.produziuEvento(pupBtnInfo);
    }

    public override void posCliqueBtnClose()
    {
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn);
        Utils.MonoBehaviour.StartCoroutine(finalizarBottomBar(pupBtnInfo));
    }

    void AcaoBotaoPUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        indiceBtn = evento;
        Utils.MonoBehaviour.StartCoroutine(mostrarBottomBar());
    }

    private IEnumerator finalizarBottomBar(PowerUpBtnInfo pupBtnInfo)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        prefabBottomBar.SetActive(false);        

        produtorDeEvento.produziuEvento(pupBtnInfo);
    }

    private IEnumerator mostrarBottomBar()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        prefabBottomBar.SetActive(true);
        btnBottomBar.subirBotao(this);
    }

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarPupEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
