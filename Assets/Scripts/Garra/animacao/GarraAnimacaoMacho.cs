using UnityEngine;

public class GarraAnimacaoMacho : AbstractGarraAnimacao
{
    private readonly int ANIM_IDLE     = Animator.StringToHash("idle");
    private readonly int ANIM_CIMA     = Animator.StringToHash("indocima");
    private readonly int ANIM_BAIXO    = Animator.StringToHash("indobaixo");
    private readonly int ANIM_DIREITA  = Animator.StringToHash("indodireita");
    private readonly int ANIM_ESQUERDA = Animator.StringToHash("indoesquerda");
    private readonly int ANIM_PISCANDO = Animator.StringToHash("piscando");
    private readonly int ANIM_FELIZ    = Animator.StringToHash("feliz");
    private readonly int ANIM_RODANDO  = Animator.StringToHash("girandov2");

    public override void irParaDireita(Animator animator)
    {
        play(ANIM_DIREITA, animator);
    }

    public override void irParaEsquerda(Animator animator)
    {
        play(ANIM_ESQUERDA, animator);
    }   

    public override void irParaBaixo(Animator animator)
    {
        play(ANIM_BAIXO, animator);
    }

    public override void irParaCima(Animator animator)
    {
        play(ANIM_CIMA, animator);
    }

    public override void comemorar(Animator animator)
    {
        play(ANIM_FELIZ, animator);
    }

    public override void piscar(Animator animator)
    {
        play(ANIM_PISCANDO, animator);
    }

    public override void girando(Animator animator)
    {
        play(ANIM_RODANDO, animator);
    }   

    public override bool isComemorando(Animator animator)
    {
        return isEstado(ANIM_FELIZ);
    }
}
