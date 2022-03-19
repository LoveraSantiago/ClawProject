using UnityEngine;

public class GarraAnimacaoFemea : AbstractGarraAnimacao
{
    private readonly int ANIM_IDLE = Animator.StringToHash("idle-femea");
    private readonly int ANIM_CIMA = Animator.StringToHash("indocima-femea");
    private readonly int ANIM_BAIXO = Animator.StringToHash("indobaixo-femea");
    private readonly int ANIM_DIREITA = Animator.StringToHash("indodireita-femea");
    private readonly int ANIM_ESQUERDA = Animator.StringToHash("indoesquerda-femea");
    private readonly int ANIM_PISCANDO = Animator.StringToHash("piscando-femea");
    private readonly int ANIM_FELIZ = Animator.StringToHash("feliz-femea");
    private readonly int ANIM_RODANDO = Animator.StringToHash("girando-femea");


    public GarraAnimacaoFemea(Animator animator) :
        base(animator)
    { }

    public override void irParaDireita()
    {
        play(ANIM_DIREITA);
    }

    public override void irParaEsquerda()
    {
        play(ANIM_ESQUERDA);
    }

    public override void irParaBaixo()
    {
        play(ANIM_BAIXO);
    }

    public override void irParaCima()
    {
        play(ANIM_CIMA);
    }

    public override void comemorar()
    {
        play(ANIM_FELIZ);
    }

    public override void piscar()
    {
        play(ANIM_PISCANDO);
    }

    public override void girando()
    {
        play(ANIM_RODANDO);
    }

    public override bool isComemorando()
    {
        return isEstado(ANIM_FELIZ);
    }
}
