using System.Collections;
using UnityEngine;

public class BotaoBottomBar 
{
    private readonly int ANIM_SUBIR   = Animator.StringToHash("subir");
    private readonly int ANIM_DESCER  = Animator.StringToHash("descer");
    private readonly int ANIM_EMCIMA  = Animator.StringToHash("emcima");
    private readonly int ANIM_EMBAIXO = Animator.StringToHash("embaixo");

    public bool animacaoEmAndamento { get; private set; }
    private int animacaoAtual;

    private Animator animator;    

    public BotaoBottomBar(
        BotaoBottomBarDto bottomBarDto, ScrollBottomBar scrollBottomBar)
    {
        bottomBarDto.BtnBottonBar.onClick.AddListener(()=> {
                btnBottomPressionado(scrollBottomBar);
                scrollBottomBar.posCliqueBtnClose();
            });

        animator = bottomBarDto.AnimatorBottonBar;
        animacaoAtual = ANIM_EMBAIXO;        
    }

    public void btnBottomPressionado(ScrollBottomBar scrollBottomBar)
    {
        if (!animacaoEmAndamento)
        {
            if (isEstadoEmbaixo())
            {
                subirBotao(scrollBottomBar);
            }
            else if (isEstadoEmCima())
            {
                descerBotao(scrollBottomBar);
            }
        }
    }

    public void subirBotao(ScrollBottomBar scrollBottomBar)
    {
        Utils.MonoBehaviour.StartCoroutine(
            coroutineAnimacao(ANIM_SUBIR, ANIM_EMCIMA, true, scrollBottomBar));
    }

    public void descerBotao(ScrollBottomBar scrollBottomBar)
    {
        Utils.MonoBehaviour.StartCoroutine(
            coroutineAnimacao(ANIM_DESCER, ANIM_EMBAIXO, false, scrollBottomBar));
    }

    private bool isEstadoEmbaixo()
    {
        return animacaoAtual == ANIM_EMBAIXO;
    }

    private bool isEstadoEmCima()
    {
        return animacaoAtual == ANIM_EMCIMA;
    }

    private IEnumerator coroutineAnimacao(int animacaoInicio, int animacaoFim, bool ligarBordas, ScrollBottomBar scrollBottomBar)
    {
        animacaoEmAndamento = true;
        animator.Play(animacaoInicio);
        yield return new WaitForSecondsRealtime(0.9f);

        animator.Play(animacaoFim);
        animacaoEmAndamento = false;

        if (ligarBordas)
        {
            scrollBottomBar.ligarBordas();
        }
        else
        {
            scrollBottomBar.desligarBordas();
        }

        animacaoAtual = animacaoFim;
    }
}
