using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScene : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;

    private float ultimaPosicao;

    void Start()
    {
        Utils.configMainMono(this);

        scrollRect.onValueChanged.AddListener((pos) => movimentado(pos));
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
}
