using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScene : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [Space(5)]
    [SerializeField] private int qtdItensVisiveis;
    [SerializeField] private RectTransform rTransformScroll;
    [SerializeField] private RectTransform[] rItens;

    private float ultimaPosicao;
    private string[] levels;

    void Start()
    {
        Utils.configMainMono(this);

        scrollRect.onValueChanged.AddListener((pos) => movimentado(pos));
        levels = LevelHelper.getAllLevelsMapsAlias();
        Debug.Log("QTD LEVELS " + levels.Length);
        calcularTamanhoScroll();
    }
    
    void Update()
    {
        
    }

    private void movimentado(Vector2 posicao)
    {
        float result = ultimaPosicao - posicao.y;
        if (result > 0)
        {
            //prateleiras.movimentarParaBaixo(prateleirasDto);
        }
        else if (result < 0)
        {
            //prateleiras.movimentarParaCima(prateleirasDto);
        }
        ultimaPosicao = posicao.y;
    }

    private void calcularTamanhoScroll()
    {
        float qtdItens = levels.Length - qtdItensVisiveis;
        float yAcrescimo = qtdItens * rItens[0].rect.height;
        rTransformScroll.offsetMin += new Vector2(0, -yAcrescimo);
    }
}
