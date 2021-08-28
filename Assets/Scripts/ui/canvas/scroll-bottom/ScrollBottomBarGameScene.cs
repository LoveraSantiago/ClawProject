using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class ScrollBottomBarGameScene : ScrollBottomBar,
                                        AcaoPUpEscolha.ConsumidorEvento
{
    private MonoBehaviour monoBehaviour;
    private GameObject prefabBottomBar;

    public ScrollBottomBarGameScene(GameObject prefabBottomBar, MonoBehaviour monoBehaviour)
       : base(prefabBottomBar, monoBehaviour)
    {
        this.prefabBottomBar = prefabBottomBar;
        this.monoBehaviour = monoBehaviour;
    }

    protected override void cliqueAcionado()
    {
        
    }

    void AcaoPUpEscolha.ConsumidorEvento.consumirEvento(int evento)
    {
        monoBehaviour.StartCoroutine(mostrarBottomBar());
    }    

    private IEnumerator mostrarBottomBar()
    {
        yield return new WaitForSecondsRealtime(1f);
        prefabBottomBar.SetActive(true);
        btnBottomBar.btnBottomPressionado();
    }
}
