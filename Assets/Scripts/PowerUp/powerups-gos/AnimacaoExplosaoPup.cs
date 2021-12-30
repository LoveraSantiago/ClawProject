using UnityEngine;

public class AnimacaoExplosaoPup 
{
    private static readonly int IDLE = Animator.StringToHash("idle");
    private static readonly int PRE_EXPLOSAO = Animator.StringToHash("pre-explosao");

    private Animator animator;

    public AnimacaoExplosaoPup(GameObject gameObject)
    {
        animator = gameObject.transform.Find("imagem").GetComponent<Animator>();
    }

    public void playIdle()
    {
        animator.Play(IDLE);
    }

    public void playPreExplodir()
    {
        animator.Play(PRE_EXPLOSAO);
    }
}
