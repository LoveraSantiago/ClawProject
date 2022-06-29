using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#pragma warning disable 0649
public class ColetaveisSceneV2 : MonoBehaviour 
{
    [SerializeField] private TimerFichaDto timerFichaDto;
    [Space(5)]
    [SerializeField] private GameObject prefabMateriais;

    private TimerFicha timerFichaOuro;

    void Start()
    {
        Utils.configMainMono(this);
        MateriaisUtils.configurar(prefabMateriais);

        timerFichaOuro = new TimerFicha(timerFichaDto, Ficha.OURO);
    }

    private void Update()
    {
        timerFichaOuro.update();
    }
}
