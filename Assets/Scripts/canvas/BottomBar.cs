using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BottomBar 
{
    private readonly int ANIM_SUBIR   = Animator.StringToHash("subir");
    private readonly int ANIM_DESCER  = Animator.StringToHash("descer");
    private readonly int ANIM_EMCIMA  = Animator.StringToHash("emcima");
    private readonly int ANIM_EMBAIXO = Animator.StringToHash("embaixo");

    private bool animacaoEmAndamento;
    private int animacaoAtual;

    private Animator animator;
    private MonoBehaviour monoBehaviour;

    public BottomBar(Animator animator, Button btnBottom, MonoBehaviour monoBehaviour)
    {
        btnBottom.onClick.AddListener(()=> btnBottomPressionado());
        this.animator = animator;
        animacaoAtual = ANIM_EMBAIXO;

        this.monoBehaviour = monoBehaviour;
    }

    public void btnBottomPressionado()
    {
        if (!animacaoEmAndamento)
        {
            if (isEstadoEmbaixo())
            {
                monoBehaviour.StartCoroutine(coroutineAnimacao(ANIM_SUBIR, ANIM_EMCIMA));
            }
            else if (isEstadoEmCima())
            {
                monoBehaviour.StartCoroutine(coroutineAnimacao(ANIM_DESCER, ANIM_EMBAIXO));
            }
        }
    }

    private bool isEstadoEmbaixo()
    {
        return animacaoAtual == ANIM_EMBAIXO;
    }

    private bool isEstadoEmCima()
    {
        return animacaoAtual == ANIM_EMCIMA;
    }

    private IEnumerator coroutineAnimacao(int animacaoInicio, int animacaoFim)
    {
        animacaoEmAndamento = true;
        animator.Play(animacaoInicio);
        yield return new WaitForSeconds(1.0f);
        animator.Play(animacaoFim);
        animacaoEmAndamento = false;

        animacaoAtual = animacaoFim;
    }
}
