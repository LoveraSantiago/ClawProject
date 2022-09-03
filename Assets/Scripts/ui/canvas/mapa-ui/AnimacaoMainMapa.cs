using UnityEngine;

public class AnimacaoMainMapa 
{
    private static readonly int GOTO_ESQUERDA     = Animator.StringToHash("trocar-mapa-esquerda");
    private static readonly int GOTO_DIREITA      = Animator.StringToHash("trocar-mapa-direita");
    private static readonly int SETAS_APARECENDO  = Animator.StringToHash("setas-aparecendo");

    private static readonly int GOTO_ESQUERDA_FAST    = Animator.StringToHash("trocar-mapa-esquerda-fast");
    private static readonly int GOTO_DIREITA_FAST     = Animator.StringToHash("trocar-mapa-direita-fast");
    private static readonly int SETAS_APARECENDO_FAST = Animator.StringToHash("setas-aparecendo-fast");

    private Animator animatorMainMapa;

    public AnimacaoMainMapa(Animator animatorMainMapa)
    {
        this.animatorMainMapa = animatorMainMapa;
    }

    public void navegarParaDireita(bool desacelerar)
    {
        if (desacelerar)
        {
            animatorMainMapa.Play(GOTO_ESQUERDA);
        }
        else
        {
            animatorMainMapa.Play(GOTO_ESQUERDA_FAST);
        }
    }

    public void navegarParaEsquerda(bool desacelerar)
    {
        if (desacelerar)
        {
            animatorMainMapa.Play(GOTO_DIREITA);
        }
        else
        {
            animatorMainMapa.Play(GOTO_DIREITA_FAST);
        }
    }

    public void mostrarSetasNavegacao(bool desacelerar)
    {
        if (desacelerar)
        {
            animatorMainMapa.Play(SETAS_APARECENDO);
        }
        else
        {
            animatorMainMapa.Play(SETAS_APARECENDO_FAST);
        }
    }
}
