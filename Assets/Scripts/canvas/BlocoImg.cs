using System.Collections;
using UnityEngine;

public class BlocoImg
{
    private readonly int ANIM_IR_ESQUERDA  = Animator.StringToHash("irEsquerda");
    private readonly int ANIM_VIR_ESQUERDA = Animator.StringToHash("virDaEsquerda");
    private readonly int ANIM_IR_DIREITA   = Animator.StringToHash("irDireita");
    private readonly int ANIM_VIR_DIREITA  = Animator.StringToHash("virDaDireita");
    private readonly int ANIM_IDLE         = Animator.StringToHash("idle");

    private bool animacaoEmAndamento;
    private BlocoImgDto blocoImgDto;
    private MonoBehaviour monoBehaviour;

    public BlocoImg(BlocoImgDto blocoImgDto, MonoBehaviour monoBehaviour)
    {
        this.blocoImgDto = blocoImgDto;
        blocoImgDto.BtnEsquerda.onClick.AddListener(()=> irParaEsquerda());
        blocoImgDto.BtnDireita.onClick.AddListener(()=> irParaDireita());
        
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
        blocoImgDto.AnimatorBlocoImg.Play(animInicio);
        yield return new WaitForSeconds(0.4f);
        blocoImgDto.AnimatorBlocoImg.Play(animFim);
        yield return new WaitForSeconds(0.4f);
        blocoImgDto.AnimatorBlocoImg.Play(ANIM_IDLE);
        animacaoEmAndamento = false;
    }
}
