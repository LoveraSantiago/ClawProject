using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ScrollBottomBarSceneGame : ScrollBottomBar,
                                        AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento,
                                        AcaoBotaoPowerUpVazio.ConsumidorEvento
{
    private int indiceBtn;
    
    private GameObject prefabBottomBar;
    private ProdutorDeEvento<PowerUpBtnInfo> produtorDeEvento;

    public ScrollBottomBarSceneGame(GameObject prefabBottomBar)
       : base(prefabBottomBar, new ItemsBottomBarPups())
    {
        this.prefabBottomBar = prefabBottomBar;
        produtorDeEvento = new ProdutorDeEvento<PowerUpBtnInfo>();
    }

    protected override void cliqueBoxAcionado(TextMeshProUGUI lblQtd)
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;        
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(int.Parse(nomeBtnSelecionado));
        int qtdPup = PlayerPrefsPup.recuperarQtdPup(pupEscolhido.nome);
        btnBottomBar.descerBotao(this);
        if(qtdPup > 0)
        {
            int qtdAtual = PlayerPrefsPup.subtrairPup(pupEscolhido.nome);
            PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);
            lblQtd.text = qtdAtual.ToString();
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
        simularCliqueBoxAcionado(indiceBtn, pupEscolhido);        
    }

    public void simularCliqueBoxAcionado(int indiceBtn, PowerUpEnums.TIPO tipoPup)
    {
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpEntidadeByEnum(tipoPup);
        simularCliqueBoxAcionado(indiceBtn, pupEscolhido);
    }

    public override void posCliqueBtnClose()
    {
        PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn);
        Utils.MonoBehaviour.StartCoroutine(finalizarBottomBar(pupBtnInfo));
    }

    private void simularCliqueBoxAcionado(int indiceBtn, PowerUpEntidade pupEscolhido)
    {
        if(pupEscolhido != null)
        {
            PowerUpBtnInfo pupBtnInfo = new PowerUpBtnInfo(indiceBtn, pupEscolhido);
            produtorDeEvento.produziuEvento(pupBtnInfo);
        }
    }

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
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

    ProdutorDeEvento<PowerUpBtnInfo> AcaoBBarItemEscolhido<PowerUpBtnInfo>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
