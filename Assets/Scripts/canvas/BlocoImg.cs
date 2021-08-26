using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocoImg
{
    private readonly int ANIM_IR_ESQUERDA  = Animator.StringToHash("irEsquerda");
    private readonly int ANIM_VIR_ESQUERDA = Animator.StringToHash("virDaEsquerda");
    private readonly int ANIM_IR_DIREITA   = Animator.StringToHash("irDireita");
    private readonly int ANIM_VIR_DIREITA  = Animator.StringToHash("virDaDireita");
    private readonly int ANIM_IDLE         = Animator.StringToHash("idle");

    private bool animacaoEmAndamento;
    private Animator animator;
    private MonoBehaviour monoBehaviour;

    public BlocoImg(Button btnEsquerda, Button btnDireita, Animator animator, MonoBehaviour monoBehaviour)
    {
        btnEsquerda.onClick.AddListener(()=> irParaEsquerda());
        btnDireita.onClick.AddListener(()=> irParaDireita());

        this.animator = animator;
        this.monoBehaviour = monoBehaviour;
    }

    public void irParaDireita()
    {
        if (!animacaoEmAndamento)
        {
            monoBehaviour.StartCoroutine(moverBloco(ANIM_IR_DIREITA, ANIM_VIR_DIREITA));
        }
    }

    public void irParaEsquerda()
    {
        if (!animacaoEmAndamento)
        {
            monoBehaviour.StartCoroutine(moverBloco(ANIM_IR_ESQUERDA, ANIM_VIR_ESQUERDA));
        }
    }

    private IEnumerator moverBloco(int animInicio, int animFim)
    {
        animacaoEmAndamento = true;
        animator.Play(animInicio);
        yield return new WaitForSeconds(0.6f);
        animator.Play(animFim);
        yield return new WaitForSeconds(0.6f);
        animator.Play(ANIM_IDLE);
        animacaoEmAndamento = false;
    }
}
