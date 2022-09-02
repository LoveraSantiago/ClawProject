using UnityEngine;

public class AnimacaoMainMapa 
{
    private static readonly int GOTOESQUERDA = Animator.StringToHash("trocar-mapa-esquerda");

    private Animator animatorMainMapa;

    public AnimacaoMainMapa(Animator animatorMainMapa)
    {
        this.animatorMainMapa = animatorMainMapa;
    }

    public void navegarParaDireita()
    {
        animatorMainMapa.Play(GOTOESQUERDA);
    }
}
