using UnityEngine;

public class AnimacaoMainMapa 
{
    private static readonly int GOTO_ESQUERDA     = Animator.StringToHash("trocar-mapa-esquerda");
    private static readonly int GOTO_DIREITA      = Animator.StringToHash("trocar-mapa-direita");
    private static readonly int SETAS_APARECENDO  = Animator.StringToHash("setas-aparecendo");

    private Animator animatorMainMapa;

    public AnimacaoMainMapa(Animator animatorMainMapa)
    {
        this.animatorMainMapa = animatorMainMapa;
    }

    public void navegarParaDireita()
    {
        animatorMainMapa.Play(GOTO_ESQUERDA);
    }

    public void navegarParaEsquerda()
    {
        animatorMainMapa.Play(GOTO_DIREITA);
    }

    public void mostrarSetasNavegacao()
    {
        animatorMainMapa.Play(SETAS_APARECENDO);
    }
}
